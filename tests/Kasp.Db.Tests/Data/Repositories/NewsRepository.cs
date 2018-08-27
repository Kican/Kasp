using Kasp.Db.Data;
using Kasp.Db.Tests.Models.NewsModel;

namespace Kasp.Db.Tests.Data.Repositories {
	public class NewsRepository : BaseRepository<AppDbContext, News> {
		public NewsRepository(AppDbContext db) : base(db) {
		}
	}
}