using System.Threading.Tasks;
using Kasp.FormBuilder.Components.Elements;
using Kasp.FormBuilder.Extensions;

namespace Kasp.FormBuilder.Components.Handlers; 

public class TextFieldComponentHandler : BaseComponentHandler<TextFieldComponent, TextFieldComponentResolver> {
	public override bool IsOwner(ComponentOptions options) => true;
}

public class TextFieldComponentResolver : BaseComponentResolver<TextFieldComponent> {
	public override Task<TextFieldComponent> ResolveAsync(ComponentOptions type) {
		Component.Name = type.Name;
		Component.Title = type.PropertyInfo.GetDisplayName();
		Component.Validators = type.Validators;
		return Task.FromResult(Component);
	}
}