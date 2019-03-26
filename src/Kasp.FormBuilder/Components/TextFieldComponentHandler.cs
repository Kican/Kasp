using System;
using System.Reflection;

namespace Kasp.FormBuilder.Components {
	public class TextFieldComponentHandler : BaseComponentHandler<TextFieldComponent> {
		public override bool IsOwner(PropertyInfo propertyInfo) => true;
		public override bool IsOwner(Type type) => true;
	}
}