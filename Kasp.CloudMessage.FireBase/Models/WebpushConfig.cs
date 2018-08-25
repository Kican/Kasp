using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kasp.CloudMessage.FireBase.Models {
	public class WebpushConfig {
		[JsonProperty("headers")]
		public Dictionary<string, string> Headers { get; set; }

		[JsonProperty("data")]
		public Dictionary<string, string> Data { get; set; }

		[JsonProperty("notification")]
		public WebpushNotification Notification { get; set; }
	}
}