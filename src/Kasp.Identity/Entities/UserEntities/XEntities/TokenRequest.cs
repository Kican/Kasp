using Newtonsoft.Json;

namespace Kasp.Identity.Entities.UserEntities.XEntities {
	public class TokenRequest {
		public string Username { get; set; }
		public string Password { get; set; }

		[JsonProperty("grant_type")]
		public GrandType GrandType { get; set; }

		[JsonProperty("refresh_token")]
		public string RefreshToken { get; set; }
	}

	public enum GrandType {
		Password = 0,
		RefreshToken = 1
	}
}