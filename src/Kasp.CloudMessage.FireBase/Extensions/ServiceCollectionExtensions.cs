using System.Net.Http;
using FirebaseAdmin;
using Kasp.CloudMessage.FireBase.Data;
using Kasp.CloudMessage.FireBase.Models;
using Kasp.CloudMessage.FireBase.Services;
using Kasp.CloudMessage.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.CloudMessage.FireBase.Extensions {
	public static class ServiceCollectionExtensions {
		public static void AddFcm<TDbContext>(this IServiceCollection builder, IConfiguration config, AppOptions options) where TDbContext : DbContext, IFcmDbContext {
			FirebaseApp.Create(options);

			builder.Configure<FcmConfig>(config);

			AddServices<TDbContext>(builder);
		}

		private static void AddServices<TDbContext>(IServiceCollection builder) where TDbContext : DbContext, IFcmDbContext {
			builder.AddScoped<IFcmUserTokenRepository, FcmUserTokenRepository<TDbContext>>();

			builder.AddScoped<FcmDeviceGroupService>();
			builder.AddScoped<IFcmService, FcmService>();
			builder.AddScoped<ICloudMessageService, FcmService>();

			var clientHandler = new HttpClientHandler {ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true};
			
			builder.AddHttpClient<FcmApiHttpClient>()
				.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler {
					ClientCertificateOptions = ClientCertificateOption.Manual,
					ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
				});
		}
	}
}