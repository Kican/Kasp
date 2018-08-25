using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kasp.CloudMessage.FireBase.Models {
	public class Message {
		[JsonProperty("data")]
		public Dictionary<string, string> Data;

		[JsonProperty("notification")]
		public Notification Notification;

		[JsonProperty("android")]
		public AndroidConfig AndroidConfig { get; set; }

		[JsonProperty("webpush")]
		public WebpushConfig WebpushConfig { get; set; }

		[JsonProperty("apns")]
		public ApnsConfig ApnsConfig { get; set; }

		[JsonProperty("token")]
		public string Token { get; set; }

		[JsonProperty("topic")]
		public string Topic { get; set; }

		[JsonProperty("condition")]
		public string Condition { get; set; }
	}
}