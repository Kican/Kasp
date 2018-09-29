using Kasp.EF.Extensions;
using Kasp.EF.Localization.Data;
using Kasp.EF.Localization.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.EF.Localization.Extensions {
	public static class ServiceCollectionExtensions {
		public static void AddDb<TDbContext>(this KaspDbServiceBuilder builder) where TDbContext : DbContext, ILocalizationDbContext {
//			builder.Services.AddSingleton<ILangRepository>(FileBasedFcmClientSettings.CreateFromFile(projectName, filePath));
			builder.Services.AddScoped<ILangRepository, LangRepository<TDbContext>>();
		}
	}
}