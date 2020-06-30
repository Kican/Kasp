using System.Text.Json.Serialization;

namespace Kasp.Authentication.Bearer.Core {
	public class TokenResponse {
		[JsonPropertyName("access_token")]
		public string AccessToken { get; set; }

		[JsonPropertyName("token_type")]
		public string TokenType { get; set; } = "Bearer";

		[JsonPropertyName("refresh_token")]
		public string RefreshToken { get; set; }

		[JsonPropertyName("expires_in")]
		public long Expires { get; set; }
	}
}