using System.Globalization;
using System.Linq;
using Kasp.Data.EF.Helpers;
using Kasp.Localization.EF.Models.Helpers;

namespace Kasp.Localization.EF {
	public class LocalizerEntityHelper : EntityHelper<ILocalizer> {
		public override IQueryable<T> QueryFilter<T>(IQueryable<T> queryable) => queryable.Where(x => (x as ILocalizer).LangId == CultureInfo.CurrentCulture.Name);
	}
}