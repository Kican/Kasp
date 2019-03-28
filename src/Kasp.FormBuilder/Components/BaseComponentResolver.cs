using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Kasp.FormBuilder.Components {
	public abstract class BaseComponentResolver<TComponent> : IComponentResolver<TComponent> where TComponent : IComponent, new() {
		public TComponent Component = new TComponent();
		public BaseComponentResolver() {
			Component.Type = typeof(TComponent).Name;
		}
		
		public abstract Task<TComponent> ResolveAsync(Type type);
		async Task<IComponent> IComponentResolver.ResolveAsync(PropertyInfo propertyInfo) => await ResolveAsync(propertyInfo);
		async Task<IComponent> IComponentResolver.ResolveAsync(Type type) => await ResolveAsync(type);
		public abstract Task<TComponent> ResolveAsync(PropertyInfo propertyInfo);
	}
}