using Kasp.Core.Extensions;
using Kasp.EF.Extensions;
using Kasp.EF.Tests.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.EF.Tests {
	public class StartupDb {
		public StartupDb(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			var mvc = services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddEntityFrameworkInMemoryDatabase();
			services.AddKasp(Configuration, mvc)
				.AddDataBase<AppDbContext>(builder => builder.UseInMemoryDatabase("dbTest"))
				.AddRepositories();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
			app.UseKasp().UseDataBase();

			app.UseStaticFiles();
			app.UseMvc();
		}
	}
}