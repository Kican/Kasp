using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kasp.CloudMessage.FireBase.Models.UserTokenModels;
using Kasp.Db.Data;
using Microsoft.EntityFrameworkCore;

namespace Kasp.CloudMessage.FireBase.Data {
	public class FcmUserTokenRepository<TDbContext> : BaseRepository<TDbContext, FcmUserToken>, IFcmUserTokenRepository where TDbContext : DbContext, IFcmDbContext {
		public FcmUserTokenRepository(TDbContext db) : base(db) {
		}

		public async Task<string> GetUserTokenAsync(int userId, CancellationToken cancellationToken = default) {
			var result = await BaseQuery.FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
			return result != null ? result.Token : "";
		}

		public async Task UpdateUserTokenAsync(int userId, string token, CancellationToken cancellationToken = default) {
			var item = await GetAsync(x => x.UserId == userId, cancellationToken);
			if (item == null)
				await AddAsync(new FcmUserToken {UserId = userId, Token = token}, cancellationToken);
			else {
				item.Token = token;
				Update(item);
			}

			await SaveAsync(cancellationToken);
		}

		public async Task<List<string>> GetUsersTokensAsync(List<int> usersId, CancellationToken cancellationToken = default) {
			return await Set.Where(x => usersId.Contains(x.UserId)).Select(x => x.Token).ToListAsync(cancellationToken);
		}
	}
}