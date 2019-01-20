using Kasp.EF.Data;
using Kasp.EF.Localization.Models;
using Microsoft.EntityFrameworkCore;

namespace Kasp.EF.Localization.Data.Repositories {
	public class LangRepository<TDbContext> : EFBaseRepository<TDbContext, Lang, string>, ILangRepository where TDbContext : DbContext {
		public LangRepository(TDbContext db) : base(db) {
		}
	}
}