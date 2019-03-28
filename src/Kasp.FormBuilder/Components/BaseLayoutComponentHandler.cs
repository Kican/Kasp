namespace Kasp.FormBuilder.Components {
	public abstract class BaseLayoutComponentHandler<TComponent, TComponentResolver> : BaseComponentHandler<TComponent, TComponentResolver>
		where TComponent : ILayoutComponent, new()
		where TComponentResolver : IComponentResolver<TComponent> {
		
	}
}