using System;
using Kasp.Core.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Kasp.Localization.Extensions {
	public static class AppBuilderExtensions {
		public static KaspAppBuilder UseRequestLocalization(this KaspAppBuilder app, Action<KaspRequestLocalizationOptions> optionsAction = null) {
			var localizationOptions = app.ApplicationBuilder.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;

			var options = new KaspRequestLocalizationOptions(app.ApplicationBuilder.ApplicationServices, localizationOptions);

			optionsAction?.Invoke(options);

			app.ApplicationBuilder.UseRequestLocalization(localizationOptions);
			return app;
		}
	}
}