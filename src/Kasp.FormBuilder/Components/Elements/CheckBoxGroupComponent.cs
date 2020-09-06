using System.Collections.Generic;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Components.Elements {
	public class CheckBoxGroupComponent : BaseComponent, IComponentTitle {
		public string Title { get; set; }
		public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();
	}
}