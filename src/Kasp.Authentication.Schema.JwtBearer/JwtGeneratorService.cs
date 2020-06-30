using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Kasp.Authentication.Bearer.Core;
using Kasp.Authentication.Schema.JwtBearer.Core;
using Kasp.Identity.Core.Entities.UserEntities.XEntities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace Kasp.Identity.Schema.JwtBearer {
	public class JwtGeneratorService : IJwtGeneratorService {
		public Task<TokenResponse> GenerateTokenAsync(int userId, IEnumerable<Claim> claims, CancellationToken cancellationToken = default) {
			throw new System.NotImplementedException();
		}

		public Task<ClaimsPrincipal> DecodeTokenAsync(string token, CancellationToken cancellationToken = default) {
			throw new System.NotImplementedException();
		}
	}
}