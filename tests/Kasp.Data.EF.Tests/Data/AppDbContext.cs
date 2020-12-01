using Kasp.Data.EF.Tests.Models.NewsModel;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Data.EF.Tests.Data {
	public class AppDbContext : DbContext {
		public DbSet<News> Newses { get; set; }
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
		}
	}
}
