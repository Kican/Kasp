using Kasp.Data.EF.Data;
using Kasp.Localization.EF.Tests.Models;

namespace Kasp.Localization.EF.Tests.Data {
	public class PostRepository : EFBaseRepository<LocalizationDbContext, Post> {
		public PostRepository(LocalizationDbContext db) : base(db) {
		}
	}
}