using System;
using System.Collections.Generic;

namespace Kasp.Panel.Options {
	public class PanelOptions {
		public List<OptionDto> Options { get; set; } = new List<OptionDto>();

	}

	public class OptionDto : OptionData {
		public Type Type { get; set; }
	}
}