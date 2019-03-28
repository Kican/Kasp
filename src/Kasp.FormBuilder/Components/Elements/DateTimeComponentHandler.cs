using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Kasp.FormBuilder.Components.Elements {
	public class DateTimeComponentHandler : BaseComponentHandler<DateTimeComponent, DateTimeComponentResolver> {
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

	public class DateTimeComponentResolver : BaseComponentResolver<DateTimeComponent> {
		public override Task<DateTimeComponent> ResolveAsync(Type type) {
			throw new NotImplementedException();
		}

		public override Task<DateTimeComponent> ResolveAsync(PropertyInfo propertyInfo) {
			throw new NotImplementedException();
		}
	}
}