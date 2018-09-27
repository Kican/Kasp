using Kasp.Core.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;

namespace Kasp.Db.Localization.Tests.Controllers {
	public class CultureController : ApiController {
		public CultureController(IRequestCultureFeature cultureFeature, RequestLocalizationOptions localizationOptions) {
			CultureFeature = cultureFeature;
			LocalizationOptions = localizationOptions;
		}

		private IRequestCultureFeature CultureFeature { get;  }
		private RequestLocalizationOptions LocalizationOptions { get;  }

		public void x() {
//			CultureFeature.RequestCulture.
		}
	}
}