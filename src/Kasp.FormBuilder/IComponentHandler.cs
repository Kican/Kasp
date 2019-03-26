using System;
using System.Reflection;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder {
	public interface IComponentHandler {
		bool IsOwner(PropertyInfo propertyInfo);
		bool IsOwner(Type type);

		IComponent Process();
	}
}