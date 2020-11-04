using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Kasp.CloudMessage.FireBase.Models {
	public class FcmConfig {
		public string ServerKey { get; set; }
		public string SenderId { get; set; }
	}

	public class FcmMessage {
		[JsonPropertyName("to")]
		public string To { get; set; }

		[JsonPropertyName("notification")]
		public FcmNotification Notification { get; set; }

		[JsonPropertyName("data")]
		public Dictionary<string, string> Data { get; set; }
	}

	public class FcmNotification {
		[JsonPropertyName("title")]
		public string Title { get; set; }

		[JsonPropertyName("body")]
		public string Body { get; set; }

		[JsonPropertyName("image")]
		public string Image { get; set; }

		[JsonPropertyName("icon")]
		public string Icon { get; set; }
	}
}
