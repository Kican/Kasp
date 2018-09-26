using System;
using System.Globalization;
using System.Text;

namespace Kasp.Localization.JsonLocalizer {
	public class JsonLocalizationOptions : KaspLocalizationOptions {
		public TimeSpan CacheDuration { get; set; } = TimeSpan.FromMinutes(30);
		public Encoding FileEncoding { get; set; } = Encoding.UTF8;

		public override Type StringLocalizerFactory { get; set; } = typeof(JsonStringLocalizerFactory);
		public override Type StringLocalizer { get; set; } = typeof(JsonStringLocalizer);
	}
}