using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Kasp.CloudMessage.FireBase.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kasp.CloudMessage.FireBase {
	public class FcmApiHttpClient {
		public HttpClient Client { get; }

		public FcmApiHttpClient(HttpClient client, IOptions<FcmConfig> option, ILogger<FcmApiHttpClient> logger) {
			client.BaseAddress = new Uri("https://fcm.googleapis.com/fcm/");
			client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=" + option.Value.ServerKey);
			client.DefaultRequestHeaders.TryAddWithoutValidation("project_id", option.Value.SenderId);
			Client = client;
		}


		public async Task SendAsync(FcmMessage message, CancellationToken cancellationToken = default) {
			var content = new StringContent(JsonSerializer.Serialize(message), Encoding.UTF8, "application/json");
			var response = await Client.PostAsync("send", content, cancellationToken);
		}
	}
}
