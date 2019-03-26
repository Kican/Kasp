using System;
using System.Reflection;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder {
	public abstract class BaseComponentHandler<TComponent> : IComponentHandler where TComponent : IComponent, new() {
		protected TComponent Component { get; set; } = new TComponent();
		
		public abstract bool IsOwner(PropertyInfo propertyInfo);
		public abstract bool IsOwner(Type type);

		public IComponent Process() {


			return Component;
		}
	}
}