using System.Globalization;
using System.Linq;
using Kasp.Core.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Kasp.EF.Localization.Tests.Controllers {
	public class LangController : ApiController {
		public LangController(IOptions<RequestLocalizationOptions> localizationOptions) {
			LocalizationOptions = localizationOptions.Value;
		}

		private RequestLocalizationOptions LocalizationOptions { get; }

		public ActionResult<string> Culture() {
			return CultureInfo.CurrentCulture.Name;
		}

		public ActionResult<string> CurrentCulture() {
			var cultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
			return cultureFeature.RequestCulture.Culture.Name;
		}

		public ActionResult<string[]> Cultures() {
			return LocalizationOptions.SupportedCultures.Select(x => x.Name).ToArray();
		}
	}
}