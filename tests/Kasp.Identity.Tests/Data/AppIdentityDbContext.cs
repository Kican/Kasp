using Kasp.Identity.Core.Entities.UserEntities;
using Kasp.Identity.Tests.Models.UserModels;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Identity.Tests.Data {
	public class AppIdentityDbContext : KIdentityDbContext<AppUser, KaspRole> {
		public AppIdentityDbContext(DbContextOptions options) : base(options) {
		}
	}
}