using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Kasp.FormBuilder.Services;

namespace Kasp.FormBuilder.Components.Layouts {
	public class LinearLayoutComponentHandler : BaseLayoutComponentHandler<LinearLayoutComponent, LinearLayoutComponentResolver> {
		public override bool IsOwner(ComponentOptions options) {
			return options.Type.IsClass && options.Type.GetProperties().Length > 0 && !options.Type.IsPrimitive && options.Type.Name != "String";
		}
	}

	public class LinearLayoutComponentResolver : BaseComponentResolver<LinearLayoutComponent> {
		public LinearLayoutComponentResolver(IFormBuilder formBuilder) {
			FormBuilder = formBuilder;
		}

		private IFormBuilder FormBuilder { get; }

		public override async Task<LinearLayoutComponent> ResolveAsync(ComponentOptions options) {
			Component.Children = new List<IComponent>();

			foreach (var property in options.Type.GetProperties()) {
				Component.Children.Add(await FormBuilder.FromProperty(property));
			}

			return Component;
		}
	}
}