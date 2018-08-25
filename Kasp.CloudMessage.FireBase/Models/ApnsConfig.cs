using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kasp.CloudMessage.FireBase.Models {
	public class ApnsConfig {
		[JsonProperty("headers")]
		public Dictionary<string, string> Headers { get; set; }

		[JsonProperty("payload")]
		public ApnsConfigPayload Payload { get; set; }
	}
}