using Microsoft.AspNetCore.Mvc;

namespace Kasp.Core.Controllers {
	[Route("api/[controller]/[action]")]
	public abstract class ApiController : ControllerBase {
	}
}