using Newtonsoft.Json;

namespace Kasp.CloudMessage.FireBase.Models {
	public class WebpushNotification {
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("body")]
		public string Body { get; set; }

		[JsonProperty("icon")]
		public string Icon { get; set; }
	}
}