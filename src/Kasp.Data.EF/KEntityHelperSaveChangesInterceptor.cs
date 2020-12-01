using System.Threading;
using System.Threading.Tasks;
using Kasp.Data.EF.Helpers;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Kasp.Data.EF {
	public class KEntityHelperSaveChangesInterceptor : SaveChangesInterceptor {
		public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result) {
			EntityHelperFactory.GetHelpers().ForEach(helper => helper.EntityModifier(eventData.Context.ChangeTracker));

			return base.SavingChanges(eventData, result);
		}

		public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = new()) {
			EntityHelperFactory.GetHelpers().ForEach(helper => helper.EntityModifier(eventData.Context.ChangeTracker));

			return base.SavingChangesAsync(eventData, result, cancellationToken);
		}
	}
}
