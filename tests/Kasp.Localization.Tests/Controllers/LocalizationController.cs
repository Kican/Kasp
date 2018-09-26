using Kasp.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Kasp.Localization.Tests.Controllers {
	public class LocalizationController : ApiController {
		public LocalizationController(IStringLocalizer<LocalizationController> localizer) {
			Localizer = localizer;
		}

		public IStringLocalizer<LocalizationController> Localizer { get; set; }

		public ActionResult<string> Index() {
			return Localizer["hello"].Value;
		}

		public ActionResult<string> NotExistKey() {
			var result = Localizer["Not-Exist"];
			return result.Value;
		}
	}
}