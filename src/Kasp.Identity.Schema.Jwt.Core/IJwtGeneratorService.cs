using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Kasp.Identity.Core.Entities.UserEntities.XEntities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Identity.Schema.Jwt.Core {
	public interface IJwtGeneratorService {
		Task<TokenResponse> GenerateTokenAsync(int userId, IEnumerable<Claim> claims, CancellationToken cancellationToken = default);
		Task<ClaimsPrincipal> DecodeTokenAsync(string token, CancellationToken cancellationToken = default);
	}
}