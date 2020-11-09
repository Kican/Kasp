using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Kasp.CloudMessage.FireBase.Models.FcmDeviceGroupModels {
	public class DeviceGroupRequest {
		[JsonPropertyName("operation")]
		public string Operation { get; set; }

		[JsonPropertyName("notification_key_name")]
		public string NotificationKeyName { get; set; }

		[JsonPropertyName("notification_key")]
		public string NotificationKey { get; set; }

		[JsonPropertyName("registration_ids")]
		public List<string> RegistrationIds { get; set; }
	}
}