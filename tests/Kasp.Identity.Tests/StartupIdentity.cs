using System.Threading.Tasks;
using Kasp.Core.Extensions;
using Kasp.Data.EF.Extensions;
using Kasp.Identity.Entities.UserEntities;
using Kasp.Identity.Extensions;
using Kasp.Identity.Services;
using Kasp.Identity.Tests.Data;
using Kasp.Identity.Tests.Models.UserModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Identity.Tests {
	public class StartupIdentity {
		public StartupIdentity(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			var mvc = services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


			services.AddEntityFrameworkInMemoryDatabase();
			services.AddKasp(Configuration, mvc)
				.AddDataBase<AppIdentityDbContext>(builder => builder.UseInMemoryDatabase("dbTest"))
				.AddEFRepositories()
				.AddIdentity<AppUser, KaspRole, AppIdentityDbContext>()
				.AddJwt(Configuration.GetJwtConfig());

			services.AddAuthentication()
				.AddJwtBearer(Configuration.GetJwtConfig());

			services.AddSingleton<IAuthOtpSmsSender, AuthOtpSmsSender>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
			app.UseKasp().UseDataBase<AppIdentityDbContext>();

			app.UseAuthentication();

			app.UseStaticFiles();
			app.UseMvc();
		}
	}

	public class AuthOtpSmsSender : IAuthOtpSmsSender {
		public static string Code = "0";
		public Task<SmsResult> SendSmsAsync(string number, string code) {
			Code = code;
			return Task.FromResult(new SmsResult {number = "10002000", isSuccess = true});
		}
	}
}