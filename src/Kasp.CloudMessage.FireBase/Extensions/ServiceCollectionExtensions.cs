using System;
using FcmSharp;
using FcmSharp.Http.Client;
using FcmSharp.Settings;
using Kasp.CloudMessage.FireBase.Data;
using Kasp.CloudMessage.FireBase.Models;
using Kasp.CloudMessage.FireBase.Services;
using Kasp.EF.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.CloudMessage.FireBase.Extensions {
	public static class ServiceCollectionExtensions {
		public static void AddFcm<TDbContext>(this KaspDbServiceBuilder builder, string projectName, string filePath) where TDbContext : DbContext, IFcmDbContext {
			builder.Services.AddSingleton<IFcmClientSettings>(FileBasedFcmClientSettings.CreateFromFile(projectName, filePath));

			AddServices<TDbContext>(builder);
		}

		private static void AddServices<TDbContext>(KaspDbServiceBuilder builder) where TDbContext : DbContext, IFcmDbContext {
			var fcmConfig = builder.Configuration.GetSection("Fcm");

			if (fcmConfig == null)
				throw new NullReferenceException("you must define fcm config");

			builder.Services.Configure<FcmConfig>(fcmConfig);

			builder.Services.AddScoped<IFcmUserTokenRepository, FcmUserTokenRepository<TDbContext>>();

			builder.Services.AddSingleton<IFcmHttpClient, FcmHttpClient>();
			builder.Services.AddSingleton<IFcmClient, FcmClient>();
			builder.Services.AddScoped<FcmDeviceGroupService>();
			builder.Services.AddScoped<IFcmService, FcmService>();

			builder.Services.AddHttpClient<FcmApiHttpClient>();
		}
	}
}