using System.Text.Json.Serialization;

namespace Kasp.CloudMessage.FireBase.Models.FcmDeviceGroupModels {
	public class DeviceGroupResponse {
		[JsonPropertyName("notification_key")]
		public string NotificationKey { get; set; }
	}
}