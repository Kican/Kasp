using Kasp.Db.Extensions;
using Kasp.Db.Localization.Data;
using Kasp.Db.Localization.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Db.Localization.Extensions {
	public static class ServiceCollectionExtensions {
		public static void AddDb<TDbContext>(this KaspDbServiceBuilder builder) where TDbContext : DbContext, ILocalizationDbContext {
//			builder.Services.AddSingleton<ILangRepository>(FileBasedFcmClientSettings.CreateFromFile(projectName, filePath));
			builder.Services.AddScoped<ILangRepository, LangRepository<TDbContext>>();
		}
	}
}