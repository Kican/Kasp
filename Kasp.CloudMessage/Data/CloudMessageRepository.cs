using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kasp.CloudMessage.Models;
using Kasp.CloudMessage.Models.TokenModels;
using Kasp.Db.Data;
using Microsoft.EntityFrameworkCore;

namespace Kasp.CloudMessage.Data {
	public class CloudMessageRepository<TDbContext> : BaseRepository<TDbContext, UserCloudMessageToken>, ICloudMessageRepository where TDbContext : DbContext {
		public CloudMessageRepository(TDbContext db) : base(db) {
		}

		public async Task<List<string>> GetUserTokens(int userId) {
			return await BaseQuery.Where(x => x.UserId == userId).Select(x => x.Token).ToListAsync();
		}

		public async Task<List<string>> GetUsersTokens(List<int> usersId) {
			return await Set.Where(x => usersId.Contains(x.UserId)).Select(x => x.Token).Distinct().ToListAsync();
		}
	}
}