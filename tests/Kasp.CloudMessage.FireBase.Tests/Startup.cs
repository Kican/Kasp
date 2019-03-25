using Kasp.CloudMessage.FireBase.Extensions;
using Kasp.CloudMessage.FireBase.Tests.Data;
using Kasp.Core.Extensions;
using Kasp.Data.EF.Extensions;
using Kasp.Test.EF.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.CloudMessage.FireBase.Tests {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			var mvc = services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddEntityFrameworkInMemoryDatabase();
			services.AddKasp(Configuration, mvc)
				.AddDataBase<AppDbContext>(builder => builder.UseInMemoryDatabase("AppDb"))
				.AddEFRepositories()
				.AddFcm<AppDbContext>("test", "test.json");
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, AppDbContext dbContext) {
			app.UseKasp().UseTestDataBase<AppDbContext>();

			app.UseStaticFiles();
			app.UseMvc();
		}
	}
}