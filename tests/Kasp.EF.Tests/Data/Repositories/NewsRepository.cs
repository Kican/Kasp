using Kasp.EF.Data;
using Kasp.EF.Tests.Models.NewsModel;

namespace Kasp.EF.Tests.Data.Repositories {
	public class NewsRepository : EFBaseRepository<AppDbContext, News> {
		public NewsRepository(AppDbContext db) : base(db) {
		}
	}
}