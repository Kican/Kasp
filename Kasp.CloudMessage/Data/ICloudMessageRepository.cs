using System.Collections.Generic;
using System.Threading.Tasks;
using Kasp.CloudMessage.Models;
using Kasp.CloudMessage.Models.TokenModels;
using Kasp.Db.Data;

namespace Kasp.CloudMessage.Data {
	public interface ICloudMessageRepository : IBaseRepository<UserCloudMessageToken> {
		Task<List<string>> GetUserTokens(int userId);
		Task<List<string>> GetUsersTokens(List<int> usersId);
	}
}