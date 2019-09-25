using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Kasp.Core.Extensions {
	public static class HttpExtensions {
		public static async Task<T> ReadAsAsync<T>(this HttpContent content) {
			return await JsonSerializer.DeserializeAsync<T>(await content.ReadAsStreamAsync(), new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
		}

		public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, string requestUri, T value) {
			return client.PostAsJsonAsync(requestUri, value, CancellationToken.None);
		}

		public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, string requestUri, T value, CancellationToken cancellationToken) {
			var content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
			return client.PostAsync(requestUri, content, cancellationToken);
		}

		public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, Uri requestUri, T value) {
			return client.PostAsJsonAsync(requestUri, value, CancellationToken.None);
		}


		public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, Uri requestUri, T value, CancellationToken cancellationToken) {
			var content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
			return client.PostAsync(requestUri, content, cancellationToken);
		}
	}
}