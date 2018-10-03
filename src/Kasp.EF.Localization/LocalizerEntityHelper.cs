using System.Globalization;
using System.Linq;
using Kasp.EF.Helpers;
using Kasp.EF.Localization.Models.Helpers;

namespace Kasp.EF.Localization {
	public class LocalizerEntityHelper : EntityHelper<ILocalizer> {
		public override IQueryable<T> QueryFilter<T>(IQueryable<T> queryable) => queryable.Where(x => (x as ILocalizer).LangId == CultureInfo.CurrentCulture.Name);
	}
}