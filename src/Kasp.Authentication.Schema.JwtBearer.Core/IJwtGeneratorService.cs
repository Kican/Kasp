using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Kasp.Authentication.Bearer.Core;

namespace Kasp.Authentication.Schema.JwtBearer.Core {
	public interface IJwtGeneratorService {
		Task<TokenResponse> GenerateTokenAsync(int userId, IEnumerable<Claim> claims, CancellationToken cancellationToken = default);
		Task<ClaimsPrincipal> DecodeTokenAsync(string token, CancellationToken cancellationToken = default);
	}
}