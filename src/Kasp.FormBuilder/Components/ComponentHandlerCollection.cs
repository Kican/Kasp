using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Kasp.FormBuilder.Components.Elements;
using Kasp.FormBuilder.Components.Layouts;

namespace Kasp.FormBuilder.Components {
	public class ComponentHandlerCollection : IEnumerable<Type> {
		private ICollection<Type> Handlers { get; } = new List<Type>();

		public ComponentHandlerCollection() {
			Add<LinearLayoutComponentHandler>();

			Add<DateTimeComponentHandler>();
			Add<TextFieldComponentHandler>();
		}

		public void Add<THandler>() where THandler : class, IComponentHandler {
			Handlers.Add(typeof(THandler));
		}

		public void Remove<THandler>() where THandler : class, IComponentHandler {
			Handlers.Remove(typeof(THandler));
		}

//		public IComponentHandler FindHandler(Type type) => this.First(x => x.IsOwner(type));
		public IEnumerator<Type> GetEnumerator() {
			return Handlers.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
}