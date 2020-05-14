using Kasp.ObjectMapper.Extensions;
using Kasp.ObjectMapper.Tests.Models;
using Mapster;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.ObjectMapper.Mapster.Tests {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			TypeAdapterConfig.GlobalSettings.AllowImplicitDestinationInheritance = true;

			
			TypeAdapterConfig<User, UserUpdateModel>
				.NewConfig()
				.IgnoreNullValues(true)
				.TwoWays();
			

			TypeAdapterConfig<User, UserVm>
				.NewConfig()
				.Map(dest => dest.FullName, src => $"{src.Name} {src.Family}");

			services.AddObjectMapper<Mapster>();

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
			app.UseObjectMapper();
			app.UseRouting();

			app.UseEndpoints(builder => builder.MapControllers());
		}
	}
}