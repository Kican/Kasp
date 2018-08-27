using System;
using System.Net.Http;
using Kasp.CloudMessage.FireBase.Models;
using Microsoft.Extensions.Options;

namespace Kasp.CloudMessage.FireBase {
	public class FcmApiHttpClient {
		public FcmApiHttpClient(HttpClient client, IOptions<FcmConfig> option) {
			client.BaseAddress = new Uri("https://fcm.googleapis.com/fcm/");
			client.DefaultRequestHeaders.Add("Authorization", "key=" + option.Value.ServerKey);
			client.DefaultRequestHeaders.Add("project_id", option.Value.SenderId);
			Client = client;
		}

		public HttpClient Client { get; }
	}
}