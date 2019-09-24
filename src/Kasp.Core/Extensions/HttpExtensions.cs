using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kasp.Core.Extensions {
	public static class HttpExtensions {
		public static async Task<T> ReadAsAsync<T>(this HttpContent content) {
			return await JsonSerializer.DeserializeAsync<T>(await content.ReadAsStreamAsync());
		}
	}
}