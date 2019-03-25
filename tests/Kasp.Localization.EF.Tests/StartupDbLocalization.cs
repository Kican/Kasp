using Kasp.Core.Extensions;
using Kasp.Data.EF.Extensions;
using Kasp.Localization.EF.Data.Repositories;
using Kasp.Localization.EF.Extensions;
using Kasp.Localization.EF.Models;
using Kasp.Localization.EF.Tests.Data;
using Kasp.Localization.Extensions;
using Kasp.Test.EF.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Localization.EF.Tests {
	public class StartupDbLocalization {
		public StartupDbLocalization(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			var mvc = services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddEntityFrameworkInMemoryDatabase();
			
			var supportedCultures = new[] {"en-US"};

			services.AddKasp(Configuration, mvc)
				.AddDataBase<LocalizationDbContext>(builder => builder.UseInMemoryDatabase("LocalizationDb"))
				.AddEFRepositories()
				.AddLocalization(builder => {
					builder.SetCultures(supportedCultures, supportedCultures[0]);
					builder.AddDbLocalization<LocalizationDbContext>();
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
			var builder = app.UseKasp()
				.UseTestDataBase<LocalizationDbContext>();

			var langRepository = app.ApplicationServices.GetService<ILangRepository>();
			langRepository.AddAsync(new Lang {Id = "fa-IR", Enable = true}).Wait();
			langRepository.SaveAsync().Wait();

			builder.UseRequestLocalization(options => options.UseDb());

			app.UseMvc();
		}
	}
}