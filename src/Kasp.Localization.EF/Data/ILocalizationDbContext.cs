using Kasp.Localization.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Localization.EF.Data {
	public interface ILocalizationDbContext {
		DbSet<Lang> Langs { get; set; }
	}
}