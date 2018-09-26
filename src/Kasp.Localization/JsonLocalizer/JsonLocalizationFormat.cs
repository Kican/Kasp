using System.Collections.Generic;

namespace Kasp.Localization.JsonLocalizer {
	internal class JsonLocalizationFormat {
		public string Key { get; set; }
		public Dictionary<string, string> Values = new Dictionary<string, string>();
	}
}