using System.Threading.Tasks;
using AutoMapper;
using Kasp.Identity.Entities;
using Kasp.Identity.Entities.UserEntities;
using Kasp.Identity.Entities.UserEntities.XEntities;
using Kasp.Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Kasp.Identity.Controllers {
	public abstract class OtpAccountApiController<TUser, TRegisterModel, TViewModel, TEditModel> : UserPassAccountApiControllerBase<TUser, TRegisterModel, TViewModel, TEditModel>
		where TUser : KaspUser, new()
		where TRegisterModel : IUserRegisterModel
		where TViewModel : UserPartialVmBase
		where TEditModel : UserEditModelBase {
		protected OtpAccountApiController(IMapper mapper, IOptions<JwtConfig> config, UserManager<TUser> userManager, SignInManager<TUser> signInManager, IAuthOtpSmsSender otpSmsSender) : base(mapper,
			config, userManager, signInManager) {
			OtpSmsSender = otpSmsSender;
		}

		public IAuthOtpSmsSender OtpSmsSender { get; }

		[HttpPost, AllowAnonymous]
		public virtual async Task<IActionResult> RequestToTp([FromBody] ToTpRegisterViewModel model) {
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

			return Ok(new {smsResult.number, isRegister = isRegistered});
		}

		[HttpPost, AllowAnonymous]
		public virtual async Task<IActionResult> LoginToTp([FromBody] ToTpLoginViewModel model) {
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var user = await UserManager.FindByNameAsync(model.Phone);
			if (user == null) {
				ModelState.AddModelError("", "User not found");
			} else {
				var result = await UserManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider, model.Code);

				if (result) {
					var claims = await GetClaims(user);

					return Ok(new {access_token = GetToken(claims)});
				}

				ModelState.AddModelError("", "user/totp incurrect ...");
			}

			return BadRequest(ModelState);
		}
	}
}