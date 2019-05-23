using System.Collections.Generic;
using System.Linq;
using Kasp.Core.Extensions;
using Kasp.Localization.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Localization.Tests {
	public class StartupLocalizationJson {
		public StartupLocalizationJson(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			var supportedCultures = new List<string> {"en-US", "fa-IR"};

			services.AddLocalization(builder => {
				builder.UseJson();
				builder.SetCultures(supportedCultures, supportedCultures.Last());
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
			app.UseKasp().UseRequestLocalization();

			app.UseMvc();
		}
	}
}