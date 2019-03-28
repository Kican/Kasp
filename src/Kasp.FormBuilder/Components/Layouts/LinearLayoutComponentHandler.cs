using System;
using System.Reflection;
using System.Threading.Tasks;
using Kasp.FormBuilder.Services;

namespace Kasp.FormBuilder.Components.Layouts {
	public class LinearLayoutComponentHandler : BaseLayoutComponentHandler<LinearLayoutComponent, LinearLayoutComponentResolver> {
		public override bool IsOwner(PropertyInfo propertyInfo) => IsOwner(propertyInfo.PropertyType);

		public override bool IsOwner(Type type) {
			return type.IsClass && type.GetProperties().Length > 0;
		}
	}

	public class LinearLayoutComponentResolver : BaseComponentResolver<LinearLayoutComponent> {
		public override Task<LinearLayoutComponent> ResolveAsync(Type type) {
			throw new NotImplementedException();
		}

		public override Task<LinearLayoutComponent> ResolveAsync(PropertyInfo propertyInfo) {
			throw new NotImplementedException();
		}
	}
}