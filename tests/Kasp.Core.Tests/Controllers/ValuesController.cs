using System.Collections.Generic;
using Kasp.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.Core.Tests.Controllers; 

public class ValuesController : ApiController {
	[HttpGet]
	public ActionResult<IEnumerable<string>> Get() {
		return new[] {"value1", "value2"};
	}
}