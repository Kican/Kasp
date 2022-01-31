using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Components.Elements; 

public class SelectComponent : BaseComponent, IComponentTitle {
	public string Title { get; set; }
	public string FetchUrl { get; set; }
	public string QueryName { get; set; }
}