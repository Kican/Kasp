using System.Collections.Generic;
using Kasp.CloudMessage.FireBase.Models.Converters;
using Newtonsoft.Json;

namespace Kasp.CloudMessage.FireBase.Models {
	public class Aps {
		[JsonProperty("alert")]
		public ApsAlert Alert { get; set; }

		[JsonProperty("badge")]
		public int Badge { get; set; }

		[JsonProperty("sound")]
		public string Sound { get; set; }

		[JsonProperty("content-available")]
		[JsonConverter(typeof(BoolToIntConverter))]
		public bool ContentAvailable { get; set; }

		[JsonProperty("mutable-content")]
		[JsonConverter(typeof(BoolToIntConverter))]
		public bool MutableContent { get; set; }

		[JsonProperty("category")]
		public string Category { get; set; }

		[JsonProperty("thread-id")]
		public string ThreadId { get; set; }

		[JsonExtensionData]
		public Dictionary<string, object> CustomData { get; set; }
	}
}