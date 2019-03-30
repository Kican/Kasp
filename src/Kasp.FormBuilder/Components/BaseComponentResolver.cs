using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Kasp.FormBuilder.Components {
	public abstract class BaseComponentResolver<TComponent> : IComponentResolver<TComponent> where TComponent : IComponent, new() {
		public TComponent Component = new TComponent();

		public BaseComponentResolver() {
			Component.Type = typeof(TComponent).Name;
		}


		public abstract Task<TComponent> ResolveAsync(ComponentOptions options);

		async Task<IComponent> IComponentResolver.ResolveAsync(ComponentOptions type) => await ResolveAsync(type);
	}
}