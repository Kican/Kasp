using Kasp.Core.Extensions;
using Kasp.Db.Extensions;
using Kasp.Db.Tests.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Db.Tests {
	public class StartupDb {
		public StartupDb(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			services.AddEntityFrameworkInMemoryDatabase();
			services.AddKasp(Configuration)
				.AddDataBase<AppDbContext>(builder => builder.UseInMemoryDatabase("dbTest"))
				.AddRepositories();
			
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
			app.UseKasp().UseDataBase();

			app.UseStaticFiles();
			app.UseMvc();
		}
	}
}