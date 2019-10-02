using System;
using Kasp.Core.Controllers;
using Kasp.Core.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.Core.Tests.Controllers {
	public class ErrorController : ApiController {
		[HttpGet]
		public IActionResult NotFound(int id) {
			throw new EntityNotFoundException(id);
		}

		[HttpGet]
		public IActionResult Exist(int id) {
			throw new EntityAlreadyExistException(id);
		}

		[HttpGet]
		public IActionResult Internal() {
			throw new Exception("salam");
		}
	}
}