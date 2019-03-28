using System;
using System.Reflection;

namespace Kasp.FormBuilder.Components {
	public interface IComponentHandler {
		bool IsOwner(PropertyInfo propertyInfo);
		bool IsOwner(Type type);

		IComponent Process();
	}
}