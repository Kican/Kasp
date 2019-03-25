using Kasp.Data.EF.Data;
using Kasp.Data.EF.Tests.Models.NewsModel;

namespace Kasp.Data.EF.Tests.Data.Repositories {
	public class NewsRepository : EFBaseRepository<AppDbContext, News> {
		public NewsRepository(AppDbContext db) : base(db) {
		}
	}
}