using System;
using AutoMapper;
using Kasp.Data.EF.Extensions;
using Kasp.Data.EF.Tests.Data;
using Kasp.Data.EF.Tests.Data.Repositories;
using Kasp.ObjectMapper.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Data.EF.Tests {
	public class StartupDb {
		public StartupDb(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			services.AddEntityFrameworkInMemoryDatabase();
			services.AddDbContextPool<AppDbContext>(builder =>
				builder.UseInMemoryDatabase("AppDb")
					.AddInterceptors(new KEntityHelperSaveChangesInterceptor())
			);

			services.AddScoped<INewsRepository, NewsRepository>();
			services.AddObjectMapper<ObjectMapper.AutoMapper.AutoMapper>();

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app) {
			app.UseStaticFiles();
			app.UseObjectMapper();
			app.UseRouting();
			app.UseEndpoints(builder => builder.MapControllers());
		}
	}
}
