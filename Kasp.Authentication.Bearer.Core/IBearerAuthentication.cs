using System.Threading;
using System.Threading.Tasks;

namespace Kasp.Authentication.Bearer.Core {
	public interface IBearerAuthentication {
		Task<TokenResponse> GenerateTokenAsync(TokenRequest configuration, CancellationToken cancellationToken = default);
	}
}