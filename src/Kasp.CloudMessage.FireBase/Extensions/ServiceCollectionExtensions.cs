using FirebaseAdmin;
using Kasp.CloudMessage.FireBase.Data;
using Kasp.CloudMessage.FireBase.Services;
using Kasp.CloudMessage.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.CloudMessage.FireBase.Extensions {
	public static class ServiceCollectionExtensions {
		public static void AddFcm<TDbContext>(this IServiceCollection builder, AppOptions options) where TDbContext : DbContext, IFcmDbContext {
			FirebaseApp.Create(options);
			
			AddServices<TDbContext>(builder);
		}

		private static void AddServices<TDbContext>(IServiceCollection builder) where TDbContext : DbContext, IFcmDbContext {
			builder.AddScoped<IFcmUserTokenRepository, FcmUserTokenRepository<TDbContext>>();
			
			builder.AddScoped<IFcmService, FcmService>();
			builder.AddScoped<ICloudMessageService, FcmService>();
		}
	}
}