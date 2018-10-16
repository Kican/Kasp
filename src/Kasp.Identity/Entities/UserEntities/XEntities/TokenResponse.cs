using Newtonsoft.Json;

namespace Kasp.Identity.Entities.UserEntities.XEntities {
	public class TokenResponse {
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }

		[JsonProperty("token_type")]
		public string TokenType { get; set; } = "Bearer";

		[JsonProperty("refresh_token")]
		public string RefreshToken { get; set; }

		[JsonProperty("expires_in")]
		public long Expires { get; set; }
	}
}