using System;
using Microsoft.AspNetCore.Builder;

namespace Kasp.Localization {
	public class KaspRequestLocalizationOptions {
		public KaspRequestLocalizationOptions(IServiceProvider serviceProvider, RequestLocalizationOptions localizationOptions) {
			ServiceProvider = serviceProvider;
			LocalizationOptions = localizationOptions;
		}

		public IServiceProvider ServiceProvider { get; }
		public RequestLocalizationOptions LocalizationOptions { get; }
	}
}