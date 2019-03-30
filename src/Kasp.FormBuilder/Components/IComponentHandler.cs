using System;
using System.Reflection;

namespace Kasp.FormBuilder.Components {
	public interface IComponentHandler {
		bool IsOwner(ComponentOptions options);
		Type GetResolverType();
	}
}