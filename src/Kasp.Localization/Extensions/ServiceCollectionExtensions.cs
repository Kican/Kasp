using Kasp.Core.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace Kasp.Localization.Extensions {
	public static class ServiceCollectionExtensions {
		public static KaspServiceBuilder AddLocalization(this KaspServiceBuilder builder, KaspLocalizationOptions options) {
			builder.Services.AddLocalization(localizationOptions => localizationOptions.ResourcesPath = options.ResourcesPath);
			builder.MvcBuilder.AddViewLocalization(localizationOptions => localizationOptions.ResourcesPath = options.ResourcesPath);
//			builder.MvcBuilder.AddDataAnnotationsLocalization(options => options.)

			builder.Services.AddMemoryCache();

			if (options.StringLocalizerFactory != null)
				builder.Services.AddSingleton(typeof(IStringLocalizerFactory), options.StringLocalizerFactory);

			if (options.StringLocalizerFactory != null)
				builder.Services.AddSingleton(typeof(IStringLocalizer), options.StringLocalizer);

			return builder;
		}

		public static KaspServiceBuilder AddLocalization(this KaspServiceBuilder builder) {
			return AddLocalization(builder, new KaspLocalizationOptions());
		}
	}
}