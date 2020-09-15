using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kasp.CloudMessage.FireBase.Models.FcmDeviceGroupModels {
	public class DeviceGroupRequest {
		[JsonProperty("operation")]
		public string Operation { get; set; }

		[JsonProperty("notification_key_name")]
		public string NotificationKeyName { get; set; }

		[JsonProperty("notification_key")]
		public string NotificationKey { get; set; }

		[JsonProperty("registration_ids")]
		public List<string> RegistrationIds { get; set; }
	}
}