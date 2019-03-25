using Kasp.Data.EF.Data;
using Kasp.Localization.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Localization.EF.Data.Repositories {
	public class LangRepository<TDbContext> : EFBaseRepository<TDbContext, Lang, string>, ILangRepository where TDbContext : DbContext {
		public LangRepository(TDbContext db) : base(db) {
		}
	}
}