using System;

namespace Kasp.Panel.Options {
	public class OptionInfoAttribute : Attribute {
		public string Name { get; set; }
		public string Title { get; set; }
	}
}