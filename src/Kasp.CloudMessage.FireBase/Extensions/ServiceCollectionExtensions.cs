using System;
using FcmSharp;
using FcmSharp.Http.Client;
using FcmSharp.Settings;
using Kasp.CloudMessage.FireBase.Data;
using Kasp.CloudMessage.FireBase.Models;
using Kasp.CloudMessage.FireBase.Services;
using Kasp.Data.EF.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.CloudMessage.FireBase.Extensions {
	public static class ServiceCollectionExtensions {
		public static void AddFcm<TDbContext>(this IServiceCollection builder, string projectName, string filePath) where TDbContext : DbContext, IFcmDbContext {
			builder.AddSingleton<IFcmClientSettings>(FileBasedFcmClientSettings.CreateFromFile(projectName, filePath));

			AddServices<TDbContext>(builder);
		}

		private static void AddServices<TDbContext>(IServiceCollection builder) where TDbContext : DbContext, IFcmDbContext {
			// var fcmConfig = builder.GetSection("Fcm");

//			if (fcmConfig == null)
//				throw new NullReferenceException("you must define fcm config");

			// builder.Configure<FcmConfig>(fcmConfig);

			builder.AddScoped<IFcmUserTokenRepository, FcmUserTokenRepository<TDbContext>>();

			builder.AddSingleton<IFcmHttpClient, FcmHttpClient>();
			builder.AddSingleton<IFcmClient, FcmClient>();
			builder.AddScoped<FcmDeviceGroupService>();
			builder.AddScoped<IFcmService, FcmService>();

			builder.AddHttpClient<FcmApiHttpClient>();
		}
	}
}