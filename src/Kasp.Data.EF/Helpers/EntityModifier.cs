using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Kasp.Data.EF.Helpers {
	public class EntityModifier {
		public static void Use(ChangeTracker changeTracker) {
			EntityHelperFactory.GetHelpers().ForEach(helper =>  helper.EntityModifier(changeTracker));
		}
	}
}