using System;
using System.Linq;
using System.Threading.Tasks;
using Kasp.FormBuilder.Components.Elements;
using Kasp.FormBuilder.Extensions;

namespace Kasp.FormBuilder.Components.Handlers {
	public class EnumComponentHandler : BaseComponentHandler<DropDownComponent, EnumComponentResolver> {
		public override bool IsOwner(ComponentOptions options) => options.Type.IsEnum;
	}

	public class EnumComponentResolver : BaseComponentResolver<DropDownComponent> {
		public override Task<DropDownComponent> ResolveAsync(ComponentOptions options) {
			Component.Title = options.PropertyInfo.GetDisplayName();
			Component.Items = GetItems(options.PropertyInfo.PropertyType);
			Component.Name = options.Name;
			return Task.FromResult(Component);
		}

		private DropDownItem[] GetItems(Type type) {
			var values = Enum.GetValues(type).Cast<int>().Select(x => x.ToString()).ToArray();
			var names = Enum.GetNames(type).ToArray();

			return values.Select((t, i) => new DropDownItem{Id = t, Title = type.GetField(names[i]).GetDisplayName()}).ToArray();
		}
	}
}