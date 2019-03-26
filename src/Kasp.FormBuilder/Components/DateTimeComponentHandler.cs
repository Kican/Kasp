using System;
using System.Reflection;

namespace Kasp.FormBuilder.Components {
	public class DateTimeComponentHandler : BaseComponentHandler<DateTimeComponent> {
		public override bool IsOwner(PropertyInfo propertyInfo) {
			return IsOwner(propertyInfo.PropertyType);
		}

		public override bool IsOwner(Type type) {
			return type == typeof(DateTimeOffset) ||
			       type == typeof(DateTimeOffset?) ||
			       type == typeof(DateTime) ||
			       type == typeof(DateTime?);
		}
	}
}