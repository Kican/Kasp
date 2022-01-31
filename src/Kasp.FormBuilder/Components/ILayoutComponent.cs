using System.Collections.Generic;

namespace Kasp.FormBuilder.Components; 

public interface ILayoutComponent : IComponent {
	List<IComponent> Children { get; set; }
}