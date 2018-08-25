using Newtonsoft.Json;

namespace Kasp.CloudMessage.FireBase.Models {
	public class Notification {
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("body")]
		public string Body { get; set; }
	}
}