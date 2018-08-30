using AutoMapper;
using Kasp.Identity.Controllers;
using Kasp.Identity.Entities;
using Kasp.Identity.Entities.UserEntities.XEntities;
using Kasp.Identity.Tests.Models.UserModels;
using Kasp.Identity.Tests.Models.UserModels.XModels;
using Microsoft.Extensions.Options;

namespace Kasp.Identity.Tests.Controllers {
	public class AccountController : AccountApiControllerBase<AppUser, AppUserRegisterModel, UserPartialVmBase, UserEditModelBase> {
		public AccountController(IMapper mapper, IOptions<JwtConfig> config) : base(mapper, config) {
		}
	}
}