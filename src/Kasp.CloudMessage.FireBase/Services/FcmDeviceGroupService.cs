using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kasp.CloudMessage.FireBase.Data;
using Kasp.CloudMessage.FireBase.Models.FcmDeviceGroupModels;
using Kasp.Core.Extensions;
using Microsoft.Extensions.Logging;

namespace Kasp.CloudMessage.FireBase.Services {
	public class FcmDeviceGroupService {
		private readonly FcmApiHttpClient _fcmApiHttpClient;
		private readonly IFcmUserTokenRepository _fcmUserTokenRepository;
		private readonly ILogger<FcmDeviceGroupService> _logger;

		public FcmDeviceGroupService(FcmApiHttpClient fcmApiHttpClient, IFcmUserTokenRepository fcmUserTokenRepository, ILogger<FcmDeviceGroupService> logger) {
			_fcmApiHttpClient = fcmApiHttpClient;
			_fcmUserTokenRepository = fcmUserTokenRepository;
			_logger = logger;
		}


		public async Task<string> RequestAsync(DeviceGroupRequestOperation operation, int userId, string token, CancellationToken cancellationToken = default) {
			var data = new DeviceGroupRequest {
				NotificationKeyName = "user_" + userId,
				RegistrationIds = new List<string> {token}
			};

			if (operation == DeviceGroupRequestOperation.Create)
				data.Operation = "create";
			else {
				var prevToken = await _fcmUserTokenRepository.GetUserTokenAsync(userId, cancellationToken);
				data.NotificationKey = prevToken;
				data.Operation = operation == DeviceGroupRequestOperation.Remove ? "remove" : "add";
			}

			_logger.LogInformation("device-group-data", data);

			var response = await _fcmApiHttpClient.Client.PostAsJsonAsync("notification", data, cancellationToken);

			if (response.IsSuccessStatusCode) {
				var result = await response.Content.ReadAsAsync<DeviceGroupResponse>(cancellationToken);
				return result.NotificationKey;
			}

			var errorBody = await response.Content.ReadAsStringAsync();

			throw new Exception(errorBody);
		}
	}
}