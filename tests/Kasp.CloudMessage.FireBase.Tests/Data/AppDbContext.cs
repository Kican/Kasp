using Kasp.CloudMessage.FireBase.Data;
using Kasp.CloudMessage.FireBase.Models.UserTokenModels;
using Kasp.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace Kasp.CloudMessage.FireBase.Tests.Data {
	public class AppDbContext : DbContext, IFcmDbContext {
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
		}

		public DbSet<FcmUserToken> FcmUserTokens { get; set; }
	}
}
