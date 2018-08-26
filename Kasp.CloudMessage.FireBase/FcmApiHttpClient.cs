using System;
using System.Net.Http;

namespace Kasp.CloudMessage.FireBase {
	public class FcmApiHttpClient {
		
		public FcmApiHttpClient(HttpClient client) {
			client.BaseAddress = new Uri("https://fcm.googleapis.com/fcm/");
			client.DefaultRequestHeaders.Add("Authorization", "key=");
			Client = client;
		}

		public HttpClient Client { get; }
	}
}