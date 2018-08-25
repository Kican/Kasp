using System;
using System.Collections.Generic;
using Kasp.CloudMessage.FireBase.Models.Converters;
using Newtonsoft.Json;

namespace Kasp.CloudMessage.FireBase.Models {
	public class AndroidConfig {
		[JsonProperty("collapse_key")]
		public string CollapseKey { get; set; }

		[JsonProperty("priority")]
		[JsonConverter(typeof(AndroidMessagePriorityEnumConverter))]
		public AndroidMessagePriorityEnum Priority { get; set; }

		[JsonProperty("ttl")]
		[JsonConverter(typeof(DurationFormatConverter))]
		public TimeSpan? TimeToLive { get; set; }

		[JsonProperty("restricted_package_name")]
		public string RestrictedPackageName { get; set; }

		[JsonProperty("data")]
		public Dictionary<string, string> Data { get; set; }

		[JsonProperty("notification")]
		public AndroidNotification Notification { get; set; }
	}
}