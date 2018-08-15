using Microsoft.Extensions.Configuration;

namespace Kasp.Identity.Extensions {
	public static class JwtExtensions {
		public static IConfiguration GetJwtConfig(this IConfiguration configuration) {
			return configuration.GetSection("JWT");
		}
	}
}