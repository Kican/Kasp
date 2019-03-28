using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Kasp.FormBuilder.Components.Elements {
	public class TextFieldComponentHandler : BaseComponentHandler<TextFieldComponent,TextFieldComponentResolver> {
		public override bool IsOwner(PropertyInfo propertyInfo) => true;
		public override bool IsOwner(Type type) => true;
	}
	
	public class TextFieldComponentResolver : BaseComponentResolver<TextFieldComponent> {
		public override Task<TextFieldComponent> ResolveAsync(Type type) {
			throw new NotImplementedException();
		}

		public override Task<TextFieldComponent> ResolveAsync(PropertyInfo propertyInfo) {
			throw new NotImplementedException();
		}
	}
}