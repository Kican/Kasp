using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Kasp.FormBuilder.Components {
	public abstract class BaseComponentResolver<TComponent> : IComponentResolver<TComponent> where TComponent : IComponent {
		public abstract Task<TComponent> ResolveAsync(Type type);

		public abstract Task<TComponent> ResolveAsync(PropertyInfo propertyInfo);
	}
}