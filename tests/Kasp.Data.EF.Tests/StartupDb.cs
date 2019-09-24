using Kasp.Core.Extensions;
using Kasp.Data.EF.Extensions;
using Kasp.Data.EF.Tests.Data;
using Kasp.Test.EF.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Data.EF.Tests {
	public class StartupDb {
		public StartupDb(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			services.AddEntityFrameworkInMemoryDatabase();
			services.AddDbContextPool<AppDbContext>(builder => builder.UseInMemoryDatabase("AppDb"))
				.AddEFRepositories();

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, AppDbContext dbContext) {
			app.UseKasp().UseTestDataBase<AppDbContext>();

			app.UseStaticFiles();
			app.UseRouting();
			app.UseEndpoints(builder => builder.MapControllers());
		}
	}
}