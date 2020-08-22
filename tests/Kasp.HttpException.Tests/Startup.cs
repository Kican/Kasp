using Kasp.HttpException.Extensions;
using Kasp.HttpException.Internal;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.HttpException.Tests {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		private IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services) {
			services.AddControllers()
				.AddHttpExceptions(options => { options.ShouldLogException = exception => false; });

			services.AddLogging();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app) {
			app.UseExceptionHandler(new KaspExceptionHandlerOptions());

			app.UseRouting();

			app.UseEndpoints(builder => builder.MapControllers());
		}
	}
}