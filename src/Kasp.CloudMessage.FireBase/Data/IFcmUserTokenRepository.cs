using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kasp.CloudMessage.FireBase.Models.UserTokenModels;
using Kasp.Data.EF.Data;

namespace Kasp.CloudMessage.FireBase.Data {
	public interface IFcmUserTokenRepository : IEFBaseRepository<FcmUserToken> {
		Task<string> GetUserTokenAsync(int userId, CancellationToken cancellationToken = default);
		Task UpdateUserTokenAsync(int userId, string token, CancellationToken cancellationToken = default);
		Task<List<string>> GetUsersTokensAsync(List<int> usersId, CancellationToken cancellationToken = default);
	}
}