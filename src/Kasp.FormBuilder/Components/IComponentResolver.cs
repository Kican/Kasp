using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Kasp.FormBuilder.Components {
	public interface IComponentResolver<TComponent> : IComponentResolver where TComponent : IComponent {
		Task<TComponent> ResolveAsync(Type type);
		Task<TComponent> ResolveAsync(PropertyInfo propertyInfo);
	}

	public interface IComponentResolver {
		Task<IComponent> ResolveAsync(Type type);
		Task<IComponent> ResolveAsync(PropertyInfo propertyInfo);
	}
}