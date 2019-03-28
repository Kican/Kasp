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
		public override async Task<DateTimeComponent> ResolveAsync(Type type) {
			return Component;
		}

		public override Task<DateTimeComponent> ResolveAsync(PropertyInfo propertyInfo) {
			Component.Name = propertyInfo.Name;
			return ResolveAsync(propertyInfo.PropertyType);
		}
	}
}