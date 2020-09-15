using Newtonsoft.Json;

namespace Kasp.CloudMessage.FireBase.Models.FcmDeviceGroupModels {
	public class DeviceGroupResponse {
		[JsonProperty("notification_key")]
		public string NotificationKey { get; set; }
	}
}