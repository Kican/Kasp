using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Kasp.FormBuilder.Components.Elements {
	public class TextFieldComponentHandler : BaseComponentHandler<TextFieldComponent, TextFieldComponentResolver> {
		public override bool IsOwner(PropertyInfo propertyInfo) => true;
		public override bool IsOwner(Type type) => true;
	}

	public class TextFieldComponentResolver : BaseComponentResolver<TextFieldComponent> {
		public override async Task<TextFieldComponent> ResolveAsync(Type type) {
			return Component;
		}

		public override Task<TextFieldComponent> ResolveAsync(PropertyInfo propertyInfo) {
			Component.Name = propertyInfo.Name;
			return ResolveAsync(propertyInfo.PropertyType);
		}
	}
}