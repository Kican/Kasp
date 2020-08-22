using System.Threading.Tasks;
using Kasp.FormBuilder.Components.Elements;
using Kasp.FormBuilder.Extensions;

namespace Kasp.FormBuilder.Components.Handlers {
	public class NumberFieldComponentHandler : BaseComponentHandler<NumberFieldComponent, NumberFieldComponentResolver> {
		public override bool IsOwner(ComponentOptions options) => options.Type.IsNumberic() && !options.Type.IsEnum;
	}

	public class NumberFieldComponentResolver : BaseComponentResolver<NumberFieldComponent> {
		public override Task<NumberFieldComponent> ResolveAsync(ComponentOptions options) {
			Component.Name = options.Name;
			Component.Title = options.PropertyInfo.GetDisplayName();
			Component.Validators = options.Validators;
			return Task.FromResult(Component);
		}
	}
}