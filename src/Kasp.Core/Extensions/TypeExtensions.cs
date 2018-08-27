using System;

namespace Kasp.Core.Extensions {
	public static class TypeExtensions {
		public static string GetFullTypeName(this Type type) {
			return type.Assembly.GetName().Name + "." + type.Name;
		}


		public static bool IsNullableType(this Type type) {
			if (!type.IsGenericType)
				return false;
			return type.GetGenericTypeDefinition() == typeof(Nullable<>);
		}

		public static bool IsSubclassOfRawGeneric(this Type generic, Type toCheck) {
			while (toCheck != null && toCheck != typeof(object)) {
				var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
				if (generic == cur) {
					return true;
				}

				toCheck = toCheck.BaseType;
			}

			return false;
		}
	}
}