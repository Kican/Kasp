using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Kasp.FormBuilder.Components.Elements;
using Kasp.FormBuilder.Components.Layouts;

namespace Kasp.FormBuilder.Components {
	public class ComponentHandlerCollection : Collection<IComponentHandler> {
		public ComponentHandlerCollection() {
			Add<LinearLayoutComponentHandler>();

			Add<DateTimeComponentHandler>();
			Add<TextFieldComponentHandler>();
		}

		public void Add<THandler>() where THandler : class, IComponentHandler, new() {
			Add(new THandler());
		}
		
		public IComponentHandler FindHandler(Type type) => this.First(x => x.IsOwner(type));
		public IComponentHandler FindHandler(PropertyInfo propertyInfo) => this.First(x => x.IsOwner(propertyInfo));
	}
}