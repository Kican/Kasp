using System.Collections.ObjectModel;
using System.Linq;
using Kasp.FormBuilder.Components.Handlers;
using Kasp.FormBuilder.Components.Layouts;

namespace Kasp.FormBuilder.Components;

public class ComponentHandlerCollection : Collection<IComponentHandler> {
	public ComponentHandlerCollection() {
		Add<LinearLayoutComponentHandler>();
		Add<SelectComponentHandler>();

		Add<DateTimeComponentHandler>();
		Add<NumberFieldComponentHandler>();
		Add<EnumComponentHandler>();

		Add<TextFieldComponentHandler>();
	}

	public void Add<THandler>() where THandler : class, IComponentHandler, new() {
		Add(new THandler());
	}

	public IComponentHandler FindHandler(ComponentOptions options) => this.First(x => x.IsOwner(options));
}
