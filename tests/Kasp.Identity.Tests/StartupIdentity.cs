using System.Threading.Tasks;
using AutoMapper;
using Kasp.Core.Extensions;
using Kasp.Data.EF.Extensions;
using Kasp.Identity.Core.Entities.UserEntities;
using Kasp.Identity.Extensions;
using Kasp.Identity.Services;
using Kasp.Identity.Tests.Data;
using Kasp.Identity.Tests.Models.UserModels;
using Kasp.ObjectMapper.Extensions;
using Kasp.Test.EF.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddEntityFrameworkInMemoryDatabase();
			services.AddDbContextPool<AppIdentityDbContext>(builder => builder.UseInMemoryDatabase("dbTest"))
				.AddEFRepositories();

			services.AddIdentity<AppUser, KaspRole>()
				.AddEntityFrameworkStores<AppIdentityDbContext>()
				.AddDefaultTokenProviders()
				.AddJwt(Configuration.GetJwtConfig());

			services.AddAuthentication()
				.AddJwtBearer(Configuration.GetJwtConfig());

			services.AddAutoMapper(typeof(StartupIdentity));
			services.AddObjectMapper<ObjectMapper.AutoMapper.AutoMapper>();

			services.AddSingleton<IAuthOtpSmsSender, AuthOtpSmsSender>();

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			app.UseKasp().UseTestDataBase<AppIdentityDbContext>();

			app.UseObjectMapper();

			app.UseStaticFiles();
			app.UseRouting();
			
			app.UseAuthorization();
			app.UseAuthentication();
			
			app.UseEndpoints(builder => builder.MapControllers());
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