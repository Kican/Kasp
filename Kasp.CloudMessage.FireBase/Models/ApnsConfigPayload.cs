using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kasp.CloudMessage.FireBase.Models {
	public class ApnsConfigPayload {
		[JsonProperty("aps")]
		public Aps Aps { get; set; }

		[JsonExtensionData]
		public Dictionary<string, object> CustomData { get; set; }
	}
}