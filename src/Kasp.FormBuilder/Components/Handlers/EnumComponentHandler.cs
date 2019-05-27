using System.Threading.Tasks;
using Kasp.FormBuilder.Components.Elements;

namespace Kasp.FormBuilder.Components.Handlers {
	public class EnumComponentHandler : BaseComponentHandler<DropDownComponent, EnumComponentResolver> {
		public override bool IsOwner(ComponentOptions options) => options.Type.IsEnum;
	}

	public class EnumComponentResolver : BaseComponentResolver<DropDownComponent> {
		public override Task<DropDownComponent> ResolveAsync(ComponentOptions options) {
			throw new System.NotImplementedException();
		}
	}
}