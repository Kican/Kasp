using System;
using System.Reflection;

namespace Kasp.FormBuilder.Components {
	public abstract class BaseComponentHandler<TComponent, TComponentResolver> : IComponentHandler
		where TComponent : IComponent, new()
		where TComponentResolver : IComponentResolver<TComponent> {
		protected TComponent Component { get; set; } = new TComponent();

		public abstract bool IsOwner(PropertyInfo propertyInfo);
		public abstract bool IsOwner(Type type);

		public virtual IComponent Process() {
			return Component;
		}
	}
}