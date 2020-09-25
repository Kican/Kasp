using Kasp.HttpException.Core;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.HttpException.Tests.Controllers {
	[Route("/api/data/[action]")]
	public class DataController : ControllerBase {
		[HttpGet]
		public IActionResult Get() {
			// return Ok("salam");
			throw new BadRequestException("hi");
		}

		[HttpGet]
		public IActionResult WithData() {
			// return Ok("salam");
			throw new BadRequestException("hi", new {id = 10});
		}
	}
}