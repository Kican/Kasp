using System;
using Kasp.Core.Extensions;
using Kasp.EF.Extensions;
using Kasp.EF.Helpers;
using Kasp.EF.Models.Helpers;
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

			var connectionString = Configuration.GetConnectionString("AppDb");
			if (Environment.GetEnvironmentVariable("APPVEYOR") != null)
				connectionString = "Server=localhost;Database=KaspTest;User Id=postgres;Password=Password12!;";
			
			services.AddKasp(Configuration, mvc)
				.AddDataBase<AppDbContext>(builder => {
					builder.UseNpgsql(connectionString);
					builder.AddEntityHelper<IEnable, EnableEntityHelper>();
				})
				.AddRepositories();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
			app.UseKasp().UseDataBase<AppDbContext>();

			app.UseStaticFiles();
			app.UseMvc();
		}
	}
}