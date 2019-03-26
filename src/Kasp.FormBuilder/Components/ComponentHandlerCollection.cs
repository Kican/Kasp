using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kasp.FormBuilder.Components {
	public class ComponentHandlerCollection : Collection<IComponentHandler> {
		public ComponentHandlerCollection() {
			Add(new DateTimeComponentHandler());
			Add(new TextFieldComponentHandler());
		}

		public IComponentHandler FindHandler(Type type) => this.First(x => x.IsOwner(type));
	}
}