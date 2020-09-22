using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Kasp.CloudMessage.FireBase.Data;
using Kasp.CloudMessage.FireBase.Models.FcmDeviceGroupModels;
using Kasp.Core.Extensions;

namespace Kasp.CloudMessage.FireBase.Services {
	public class FcmDeviceGroupService {
		public FcmDeviceGroupService(FcmApiHttpClient fcmApiHttpClient, IFcmUserTokenRepository fcmUserTokenRepository) {
			FcmApiHttpClient = fcmApiHttpClient;
			FcmUserTokenRepository = fcmUserTokenRepository;
		}

		private FcmApiHttpClient FcmApiHttpClient { get; }
		private IFcmUserTokenRepository FcmUserTokenRepository { get; }


		public async Task<string> RequestAsync(DeviceGroupRequestOperation operation, int userId, string token, CancellationToken cancellationToken = default) {
			var data = new DeviceGroupRequest {NotificationKeyName = userId.ToString(), RegistrationIds = new List<string> {token}};
			if (operation == DeviceGroupRequestOperation.Create)
				data.Operation = "create";
			else {
				var prevToken = await FcmUserTokenRepository.GetUserTokenAsync(userId, cancellationToken);
				data.NotificationKey = prevToken;
				data.Operation = operation == DeviceGroupRequestOperation.Remove ? "remove" : "add";
			}
			
			Console.WriteLine(JsonSerializer.Serialize(data));

			var response = await FcmApiHttpClient.Client.PostAsJsonAsync("notification", data, cancellationToken);

			if (response.IsSuccessStatusCode) {
				var result = await response.Content.ReadAsAsync<DeviceGroupResponse>(cancellationToken);
				return result.NotificationKey;
			}

			throw new Exception(response.ReasonPhrase);
		}
	}
}