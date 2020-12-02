using System.Threading;
using System.Threading.Tasks;
using Kasp.Data.EF.Data;
using Kasp.Data.EF.Tests.Models.NewsModel;
using Kasp.Data.Models;

namespace Kasp.Data.EF.Tests.Data.Repositories {
	public interface INewsRepository : IEFFilteredRepository<News, FilterBase> {
	}

	public class NewsRepository : EFFilteredRepository<AppDbContext, News>, INewsRepository {
		public NewsRepository(AppDbContext db) : base(db) {
		}

		public override Task<IPagedList<TOutput>> FilterAsync<TOutput>(FilterBase filter, CancellationToken cancellationToken = default) {
			throw new System.NotImplementedException();
		}
	}
}
