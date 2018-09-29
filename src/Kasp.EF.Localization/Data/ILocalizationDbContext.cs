using Kasp.EF.Localization.Models;
using Microsoft.EntityFrameworkCore;

namespace Kasp.EF.Localization.Data {
	public interface ILocalizationDbContext {
		DbSet<Lang> Langs { get; set; }
	}
}