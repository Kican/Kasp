using System;
using Microsoft.Extensions.Localization;

namespace Kasp.Localization {
	public class KaspLocalizationOptions : LocalizationOptions {
		public KaspLocalizationOptions() {
			ResourcesPath = "Resources";
		}

		public virtual Type StringLocalizerFactory { get; set; } = null;
		public virtual Type StringLocalizer { get; set; } = null;
	}
}