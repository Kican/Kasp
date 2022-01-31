using System.Text.Json.Serialization;

namespace Kasp.Identity.Core.Entities.UserEntities.XEntities; 

public class TokenRequest {
	public string Username { get; set; }
	public string Password { get; set; }

	[JsonPropertyName("grant_type")]
	public GrandType GrandType { get; set; }

	[JsonPropertyName("refresh_token")]
	public string RefreshToken { get; set; }
}

public enum GrandType {
	Password = 0,
	RefreshToken = 1
}