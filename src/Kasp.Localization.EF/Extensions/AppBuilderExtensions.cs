using System.Globalization;
using System.Linq;
using Kasp.Localization;
using Kasp.Localization.EF.Data.Repositories;
using Kasp.Localization.EF.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Localization.EF.Extensions {
	public static class AppBuilderExtensions {
		public static void UseDb(this KaspRequestLocalizationOptions builder) {
			var langRepository = builder.ServiceProvider.CreateScope().ServiceProvider.GetService<ILangRepository>();

			var dbCultures = langRepository.ListAsync().Result;
			
			foreach (var dbCulture in dbCultures) {
				var cultureInfo = new CultureInfo(dbCulture.Id);
				builder.LocalizationOptions.SupportedCultures.Add(cultureInfo);
				builder.LocalizationOptions.SupportedUICultures.Add(cultureInfo);
			}
	
			var newsLangs = builder.LocalizationOptions.SupportedCultures.Select(x => x.Name).Except(dbCultures.Select(x => x.Id)).ToArray();

			langRepository.AddAsync(newsLangs.Select(x => new Lang {Id = x, Enable = true})).Wait();
			langRepository.SaveAsync().Wait();
		}
	}
}