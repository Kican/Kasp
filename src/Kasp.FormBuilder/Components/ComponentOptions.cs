using System;
using System.Reflection;

namespace Kasp.FormBuilder.Components {
	public class ComponentOptions {
		public PropertyInfo PropertyInfo { get; set; }
		public Type Type { get; set; }
		public string Name { get; set; }
	}
}