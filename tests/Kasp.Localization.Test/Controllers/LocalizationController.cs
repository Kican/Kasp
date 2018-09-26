using System.Threading.Tasks;
using Kasp.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Kasp.Localization.Test.Controllers {
	public class LocalizationController : ApiController {
		public LocalizationController(IStringLocalizer<LocalizationController> localizer) {
			Localizer = localizer;
		}

		public IStringLocalizer<LocalizationController> Localizer { get; set; }
		public async Task<ActionResult<string>> Index() {
			var result = Localizer["hello"];
			return result.Value;
		}
	}
}