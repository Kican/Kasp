using System;
using System.Net.Http;
using Kasp.CloudMessage.FireBase.Models;
using Microsoft.Extensions.Options;

namespace Kasp.CloudMessage.FireBase {
	public class FcmApiHttpClient {
		public FcmApiHttpClient(HttpClient client, IOptions<FcmConfig> option) {
			client.BaseAddress = new Uri("https://fcm.googleapis.com/fcm/");
			client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=" + option.Value.ServerKey);
			client.DefaultRequestHeaders.TryAddWithoutValidation("project_id", option.Value.SenderId);
			Client = client;
		}

		public HttpClient Client { get; }
	}
}