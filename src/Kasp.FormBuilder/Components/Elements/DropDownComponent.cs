using System.Collections.Generic;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Components.Elements;

public class DropDownComponent : BaseComponent, IComponentTitle {
	public string Title { get; set; }
	public IEnumerable<DropDownItem> Items { get; set; }
	public bool IsMulti { get; set; }
}

public class DropDownItem {
	public object Id { set; get; }
	public string Title { set; get; }
}
