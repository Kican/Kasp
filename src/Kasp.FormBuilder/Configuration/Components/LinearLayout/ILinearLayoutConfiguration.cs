using Kasp.FormBuilder.Components.Layouts;

namespace Kasp.FormBuilder.Configuration.Components.LinearLayout {
	public interface ILinearLayoutConfiguration<TEntity> : ILayoutConfiguration<LinearLayoutComponent, TEntity> {
		ILinearLayoutConfiguration<TEntity> SetOrientation(LinearLayoutOrientation orientation);
	}
}