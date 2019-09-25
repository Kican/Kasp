using Kasp.Core.Controllers;
using Kasp.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.Data.Test.Controllers {
	public class PageController : ApiController {
		[HttpGet]
		public ActionResult PageBind([FromQuery] Pageable pageable) {
			return Ok(pageable);
		}
	}

	public class Pageable : IPage {
		public int Page { get; set; }
		public int Count { get; set; }
	}
}