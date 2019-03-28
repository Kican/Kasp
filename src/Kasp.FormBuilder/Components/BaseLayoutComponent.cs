namespace Kasp.FormBuilder.Components {
	public abstract class BaseLayoutComponent : BaseComponent, ILayoutComponent {
		public IComponent Child { get; set; }
	}
}