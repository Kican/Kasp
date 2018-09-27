using System;
using System.Collections.Generic;
using Kasp.Core.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;

namespace Kasp.Localization.Extensions {
	public static class AppBuilderExtensions {
		public static KaspAppBuilder UseLocalization(this KaspAppBuilder app, Action<RequestLocalizationOptions> optionsAction) {
			var options = new RequestLocalizationOptions();
			optionsAction(options);
			app.ApplicationBuilder.UseRequestLocalization(localizationOptions => {
				localizationOptions.AddSupportedCultures(options.SupportedCultures.ToArray());
				localizationOptions.AddSupportedUICultures(options.SupportedCultures.ToArray());
				localizationOptions.SetDefaultCulture(options.DefaultCulture);
			});
			return app;
		}
	}

	// todo: must be rename or change
	public class RequestLocalizationOptions {
		public List<string> SupportedCultures { get; set; }
		public string DefaultCulture { get; set; }
	}
}