using System.Threading.Tasks;
using Kasp.Identity.Core.Entities;
using Kasp.Identity.Core.Entities.UserEntities;
using Kasp.Identity.Core.Entities.UserEntities.XEntities;
using Kasp.Identity.Services;
using Kasp.ObjectMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Kasp.Identity.Controllers {
	public abstract class OtpAccountApiController<TUser, TRegisterModel, TViewModel, TEditModel> : EmailPassAccountApiControllerBase<TUser, TRegisterModel, TViewModel, TEditModel>
		where TUser : KaspUser, new()
		where TRegisterModel : IUserRegisterModel
		where TViewModel : UserPartialVmBase
		where TEditModel : UserEditModelBase {
		public IAuthOtpSmsSender OtpSmsSender { get; }

		[HttpPost, AllowAnonymous]
		public virtual async Task<ActionResult<PhoneRequestResponse>> PhoneRequest([FromBody] ToTpRegisterViewModel model) {
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var user = await UserManager.FindByNameAsync(model.Phone);

			var isRegistered = false;

			if (user == null) {
				user = new TUser {UserName = model.Phone, PhoneNumber = model.Phone};
				var result = await UserManager.CreateAsync(user);

				if (!result.Succeeded) {
					AddErrors(result);
					return BadRequest(ModelState);
				}

				await OnRegisterSuccess(user);
				isRegistered = true;
			}

			var code = await UserManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider);
			var smsResult = await OtpSmsSender.SendSmsAsync(model.Phone, code);
			if (!smsResult.isSuccess) {
				ModelState.AddModelError("sms", "sending-error");
				return BadRequest(ModelState);
			}

			return new PhoneRequestResponse(smsResult.number, isRegistered);
		}

		[HttpPost, AllowAnonymous]
		public virtual async Task<ActionResult<TokenResponse>> LoginOtp([FromBody] ToTpLoginViewModel model) {
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var user = await UserManager.FindByNameAsync(model.Phone);
			if (user == null) {
				ModelState.AddModelError("", "User not found");
			} else {
				var result = await UserManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider, model.Code);

				if (result) {
					var claims = await GetClaims(user);

					return await GetToken(claims);
				}

				ModelState.AddModelError("", "user/totp incurrect ...");
			}

			return BadRequest(ModelState);
		}

		protected OtpAccountApiController(IOptions<JwtConfig> config, UserManager<TUser> userManager, SignInManager<TUser> signInManager, IObjectMapper objectMapper, IAuthOtpSmsSender otpSmsSender) :
			base(config, userManager,
				signInManager, objectMapper) {
			OtpSmsSender = otpSmsSender;
		}
	}
}