using Kasp.Core.Controllers;
using Kasp.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.Data.Test.Controllers {
	public class PageController : ApiController {
		public ActionResult PageBind(Pageable pageable) {
			return Ok(pageable);
		}
	}
	public class Pageable : IPage {
		public int Page { get; set; }
		public int Count { get; set; }
	}
}