using System.Collections.Generic;
using System.Linq;
using Kasp.Core.Extensions;
using Kasp.Db.Extensions;
using Kasp.Db.Localization.Tests.Data;
using Kasp.Localization.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Db.Localization.Tests {
	public class StartupDbLocalization {
		public StartupDbLocalization(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			var mvc = services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddEntityFrameworkInMemoryDatabase();

			services.AddKasp(Configuration, mvc)
				.AddDataBase<LocalizationDbContext>(builder => builder.UseInMemoryDatabase("LocalizationDbTest"))
				.AddRepositories()
				.AddLocalization();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
			var supportedCultures = new List<string> {"en-US", "fa-IR"};

			app.UseKasp()
				.UseDataBase()
				.UseLocalization(options => {
					options.SupportedCultures = supportedCultures;
					options.DefaultCulture = supportedCultures.Last();
				});

			app.UseMvc();
		}
	}
}