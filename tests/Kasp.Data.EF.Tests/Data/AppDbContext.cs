using Kasp.Data.EF.Tests.Models.NewsModel;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Data.EF.Tests.Data {
	public class AppDbContext : KDbContext<AppDbContext> {
		public DbSet<News> Newses { get; set; }
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);
//			modelBuilder.Entity<News>().HasQueryFilter()
		}
	}
}