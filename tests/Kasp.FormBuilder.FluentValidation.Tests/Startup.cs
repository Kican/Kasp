using FluentValidation;
using FluentValidation.AspNetCore;
using Kasp.FormBuilder.Extensions;
using Kasp.FormBuilder.FluentValidation.Extensions;
using Kasp.FormBuilder.FluentValidation.Tests.Models;
using Kasp.FormBuilder.FluentValidation.Tests.Models.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.FormBuilder.FluentValidation.Tests {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		private IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services) {
			services.AddControllers()
				.AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<Startup>());

			services.AddFormBuilder(options => { options.AddFluentValidation(); });
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
			app.UseRouting();
			app.UseEndpoints(builder => { builder.MapControllers(); });
		}
	}
}