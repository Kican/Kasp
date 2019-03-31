using System.Linq;
using Kasp.FormBuilder.Components;

namespace Kasp.FormBuilder.Extensions {
	public static class ComponentExtensions {
		public static IComponent GetChild(this ILayoutComponent layout, string name) {
			return layout.Children.FirstOrDefault(x => x.Name == name);
		}

		public static TCast GetChild<TCast>(this ILayoutComponent layout, string name) where TCast : class, IComponent {
			return layout.GetChild(name) as TCast;
		}
	}
}