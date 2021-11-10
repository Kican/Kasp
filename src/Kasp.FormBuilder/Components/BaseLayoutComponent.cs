using System.Collections.Generic;

namespace Kasp.FormBuilder.Components;

public abstract class BaseLayoutComponent : BaseComponent, ILayoutComponent {
	public List<IComponent> Children { get; set; }
}
