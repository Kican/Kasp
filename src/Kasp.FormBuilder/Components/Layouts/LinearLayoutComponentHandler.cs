using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Kasp.FormBuilder.Services;

namespace Kasp.FormBuilder.Components.Layouts {
	public class LinearLayoutComponentHandler : BaseLayoutComponentHandler<LinearLayoutComponent, LinearLayoutComponentResolver> {
		public override bool IsOwner(PropertyInfo propertyInfo) => IsOwner(propertyInfo.PropertyType);

		public override bool IsOwner(Type type) {
			return type.IsClass && type.GetProperties().Length > 0 && !type.IsPrimitive && type.Name != "String";
		}
	}

	public class LinearLayoutComponentResolver : BaseComponentResolver<LinearLayoutComponent> {
		public LinearLayoutComponentResolver(IFormBuilder formBuilder) {
			FormBuilder = formBuilder;
		}
		private IFormBuilder FormBuilder { get; }
		
		public override async Task<LinearLayoutComponent> ResolveAsync(Type type) {
			Component.Children = new List<IComponent>();

			foreach (var property in type.GetProperties()) {
				Component.Children.Add(await FormBuilder.FromProperty(property));
			}

			return Component;
		}

		public override Task<LinearLayoutComponent> ResolveAsync(PropertyInfo propertyInfo) => ResolveAsync(propertyInfo.PropertyType);
	}
}