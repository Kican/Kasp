using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Kasp.Core.Extensions;
using Kasp.FormBuilder.Extensions;
using Kasp.FormBuilder.Services;
using Kasp.Options;
using Kasp.Options.Extensions;
using Kasp.Panel.Options.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Kasp.Panel.Options.Tests {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			services.AddControllers();
			services.AddKaspOptions(Configuration)
				.AddKaspPanelOptions(builder => builder.AddFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
			services.AddFormBuilder();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app) {
			app.UseKasp();

			app.UseRouting();

			app.UseEndpoints(builder => builder.MapControllers());
		}
	}


	[Route("/api/panel/options")]
	public class OptionsController : PanelOptionsControllerBase {
		public OptionsController(IOptions<PanelOptions> options, IFormBuilder formBuilder, IWebHostEnvironment environment) : base(options, formBuilder, environment) {
		}
	}

	[DisplayName("تنظیمات سایت")]
	public class GlobalSiteOption : IKaspOption {
		public string Title { get; set; } = "my application";
	}
}
