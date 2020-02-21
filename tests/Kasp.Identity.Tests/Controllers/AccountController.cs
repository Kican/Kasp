using Kasp.Identity.Controllers;
using Kasp.Identity.Core.Entities;
using Kasp.Identity.Core.Entities.UserEntities.XEntities;
using Kasp.Identity.Services;
using Kasp.Identity.Tests.Models.UserModels;
using Kasp.Identity.Tests.Models.UserModels.XModels;
using Kasp.ObjectMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Kasp.Identity.Tests.Controllers {
	public class AccountController : OtpAccountApiController<AppUser, AppUserRegisterModel, UserPartialVmBase, UserEditModelBase> {
		public AccountController(IOptions<JwtConfig> config, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IObjectMapper objectMapper, IAuthOtpSmsSender otpSmsSender) : base(
			config, userManager, signInManager, objectMapper, otpSmsSender) {
		}
	}
}