using System;
using System.Reflection;
using System.Threading.Tasks;
using Kasp.FormBuilder.Components.Elements;
using Kasp.FormBuilder.Extensions;

namespace Kasp.FormBuilder.Components.Handlers; 

public class SelectComponentHandler : BaseComponentHandler<SelectComponent, SelectComponentResolver> {
	public override bool IsOwner(ComponentOptions options) => options.Type.IsNumberic() && options.PropertyInfo.GetCustomAttribute<SelectAttribute>() != null;
}

public class SelectComponentResolver : BaseComponentResolver<SelectComponent> {
	public override Task<SelectComponent> ResolveAsync(ComponentOptions options) {
		var attribute = options.PropertyInfo.GetCustomAttribute<SelectAttribute>() ?? throw new Exception("`SelectAttribute` is not set");

		Component.FetchUrl = attribute.FetchUrl;
		Component.QueryName = attribute.QueryName;

		Component.Title = options.PropertyInfo.GetDisplayName();
		Component.Name = options.Name;

		return Task.FromResult(Component);
	}
}

[AttributeUsage(AttributeTargets.Property)]
public class SelectAttribute : Attribute {
	public SelectAttribute(string fetchUrl) {
		FetchUrl = fetchUrl;
	}

	public string FetchUrl { get; }
	public string QueryName { get; set; } = "q";
}