using System.Collections.Generic;

namespace Kasp.FormBuilder.Components.Layouts {
	public class LinearLayoutComponent : BaseLayoutComponent {
		public bool IsHorizontal { get; set; }
		public List<IComponent> Children { get; set; }
	}
}
