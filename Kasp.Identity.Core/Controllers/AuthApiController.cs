using Kasp.Core.Controllers;
using Kasp.Identity.Core.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Kasp.Identity.Core.Controllers {
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public abstract class AuthApiController : ApiController {
		private int _userId;

		public int UserId {
			get {
				if (_userId == 0)
					_userId = User.GetUserId();
				return _userId;
			}
		}
	}
}