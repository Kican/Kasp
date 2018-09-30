using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace Kasp.Localization {
	public class KaspLocalizationOptions : LocalizationOptions {
		public KaspLocalizationOptions() {
			ResourcesPath = "Resources";
		}

		public virtual Type StringLocalizerFactory { get; set; } = null;
		public virtual Type StringLocalizer { get; set; } = null;
	}

	public class KaspLocalizationOptionBuilder {
		public KaspLocalizationOptionBuilder(IServiceCollection serviceCollection) {
			ServiceCollection = serviceCollection;
		}

		public IServiceCollection ServiceCollection { get; }

		public KaspLocalizationOptions LocalizationOptions { get; set; }
		public List<string> SupportedCultures { get; set; }
		public string DefaultCulture { get; set; }

		public void SetCultures(IEnumerable<string> supportedCultures, string defaultCulture) {
			SupportedCultures = supportedCultures.ToList();
			DefaultCulture = defaultCulture;
		}
	}
}