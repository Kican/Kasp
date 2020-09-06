using Kasp.Panel.EntityManager.Extensions;
using Kasp.Panel.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Panel.EntityManager.Tests {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			services.AddControllers();
			services.AddEntityManager(options => options.AddFromAssembly<Startup>());
			services.AddHttpContextAccessor();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app) {
			app.UseRouting();

			app.UseEndpoints(builder => {
				builder.MapDefaultControllerRoute();
				builder.MapPanel(optionBuilder => optionBuilder.MapEntityManager());
			});
		}
	}
}