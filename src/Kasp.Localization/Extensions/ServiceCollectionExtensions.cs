using System;
using System.Linq;
using Kasp.Core.Extensions;
using Kasp.Localization.JsonLocalizer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace Kasp.Localization.Extensions {
	public static class ServiceCollectionExtensions {
		public static KaspServiceBuilder AddLocalization(this KaspServiceBuilder builder, Action<KaspLocalizationOptionBuilder> optionsAction) {
			var options = new KaspLocalizationOptionBuilder(builder.Services) {
				LocalizationOptions = new KaspLocalizationOptions()
			};

			optionsAction?.Invoke(options);

			builder.Services.AddLocalization(localizationOptions => localizationOptions.ResourcesPath = options.LocalizationOptions.ResourcesPath);
			builder.MvcBuilder.AddViewLocalization(localizationOptions => localizationOptions.ResourcesPath = options.LocalizationOptions.ResourcesPath);
//			builder.MvcBuilder.AddDataAnnotationsLocalization(options => options.)

			builder.Services.AddMemoryCache();

			if (options.LocalizationOptions.StringLocalizerFactory != null)
				builder.Services.AddSingleton(typeof(IStringLocalizerFactory), options.LocalizationOptions.StringLocalizerFactory);

			if (options.LocalizationOptions.StringLocalizerFactory != null)
				builder.Services.AddSingleton(typeof(IStringLocalizer), options.LocalizationOptions.StringLocalizer);


			builder.Services.Configure<RequestLocalizationOptions>(localizationOptions => {
				localizationOptions.AddSupportedCultures(options.SupportedCultures.ToArray());
				localizationOptions.AddSupportedUICultures(options.SupportedCultures.ToArray());
				localizationOptions.SetDefaultCulture(options.DefaultCulture);
			});

			return builder;
		}

		public static void UseJson(this KaspLocalizationOptionBuilder builder) {
			builder.LocalizationOptions = new JsonLocalizationOptions();
		}
	}
}