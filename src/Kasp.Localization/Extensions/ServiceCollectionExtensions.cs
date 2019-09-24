using System;
using Kasp.Localization.JsonLocalizer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace Kasp.Localization.Extensions {
	public static class ServiceCollectionExtensions {
		public static IServiceCollection AddLocalization(this IServiceCollection builder, Action<KaspLocalizationOptionBuilder> optionsAction) {
			var options = new KaspLocalizationOptionBuilder(builder) {
				LocalizationOptions = new KaspLocalizationOptions()
			};

			optionsAction?.Invoke(options);

			builder.AddLocalization(localizationOptions => localizationOptions.ResourcesPath = options.LocalizationOptions.ResourcesPath);
			builder.Configure<IMvcBuilder>(mvcBuilder => {
				mvcBuilder.AddViewLocalization(localizationOptions => localizationOptions.ResourcesPath = options.LocalizationOptions.ResourcesPath);
			});
//			builder.MvcBuilder.AddDataAnnotationsLocalization(options => options.)

			builder.AddMemoryCache();

			if (options.LocalizationOptions.StringLocalizerFactory != null)
				builder.AddSingleton(typeof(IStringLocalizerFactory), options.LocalizationOptions.StringLocalizerFactory);

			if (options.LocalizationOptions.StringLocalizerFactory != null)
				builder.AddSingleton(typeof(IStringLocalizer), options.LocalizationOptions.StringLocalizer);


			builder.Configure<RequestLocalizationOptions>(localizationOptions => {
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