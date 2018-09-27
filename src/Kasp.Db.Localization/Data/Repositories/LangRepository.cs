using Kasp.Db.Data;
using Kasp.Db.Localization.Models;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Db.Localization.Data.Repositories {
	public class LangRepository<TDbContext> : BaseRepository<TDbContext, Lang, string>, ILangRepository where TDbContext : DbContext {
		public LangRepository(TDbContext db) : base(db) {
		}
	}
}