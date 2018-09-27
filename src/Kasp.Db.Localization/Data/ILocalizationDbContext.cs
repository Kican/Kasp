using Kasp.Db.Localization.Models;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Db.Localization.Data {
	public interface ILocalizationDbContext {
		DbSet<Lang> Langs { get; set; }
	}
}