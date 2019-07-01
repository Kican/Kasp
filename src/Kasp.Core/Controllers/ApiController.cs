using Microsoft.AspNetCore.Mvc;

namespace Kasp.Core.Controllers {
	[Route("api/[controller]/[action]"), ApiController]
	public abstract class ApiController : ControllerBase {
	}
}