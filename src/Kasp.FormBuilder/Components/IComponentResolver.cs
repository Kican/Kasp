using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Kasp.FormBuilder.Components {
	public interface IComponentResolver<TComponent> where TComponent : IComponent {
		Task<TComponent> ResolveAsync(Type type);
		Task<TComponent> ResolveAsync(PropertyInfo propertyInfo);
	}

	public interface IComponentResolver : IComponentResolver<IComponent> {
	}
}