using Kasp.Core.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Kasp.Identity.Core.Controllers {
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public abstract class AuthApiController : ApiController {
	}
}