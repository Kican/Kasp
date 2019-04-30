using System;
using System.Reflection;
using System.Threading.Tasks;
using Kasp.FormBuilder.Extensions;

namespace Kasp.FormBuilder.Components.Elements {
	public class DateTimeComponentHandler : BaseComponentHandler<DateTimeComponent, DateTimeComponentResolver> {
		public override bool IsOwner(ComponentOptions options) {
			return options.Type == typeof(DateTimeOffset) ||
			       options.Type == typeof(DateTimeOffset?) ||
			       options.Type == typeof(DateTime) ||
			       options.Type == typeof(DateTime?);
		}
	}

	public class DateTimeComponentResolver : BaseComponentResolver<DateTimeComponent> {
		public override Task<DateTimeComponent> ResolveAsync(ComponentOptions type) {
			Component.Name = type.Name;
			Component.Title = type.PropertyInfo.GetDisplayName();
			return Task.FromResult(Component);
		}
	}
}