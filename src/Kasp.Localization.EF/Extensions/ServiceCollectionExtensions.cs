using Kasp.Data.EF.Helpers;
using Kasp.Localization;
using Kasp.Localization.EF.Data;
using Kasp.Localization.EF.Data.Repositories;
using Kasp.Localization.EF.Models.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Localization.EF.Extensions {
	public static class ServiceCollectionExtensions {
		public static void AddDbLocalization<TDbContext>(this KaspLocalizationOptionBuilder builder) where TDbContext : DbContext, ILocalizationDbContext {
			builder.ServiceCollection.AddScoped<ILangRepository, LangRepository<TDbContext>>();
			EntityHelperFactory.Add<ILocalizer, LocalizerEntityHelper>();
		}
	}
}