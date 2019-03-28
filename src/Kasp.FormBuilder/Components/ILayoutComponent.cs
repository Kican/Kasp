namespace Kasp.FormBuilder.Components {
	public interface ILayoutComponent : IComponent {
		IComponent Child { get; set; }
	}
}