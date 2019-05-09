using System.Threading.Tasks;

namespace Kasp.FormBuilder.Components.Elements {
	public class EnumComponentHandler : BaseComponentHandler<DropDownComponent, EnumComponentResolver> {
		public override bool IsOwner(ComponentOptions options) => options.Type.IsEnum;
	}

	public class EnumComponentResolver : BaseComponentResolver<DropDownComponent> {
		public override Task<DropDownComponent> ResolveAsync(ComponentOptions options) {
			throw new System.NotImplementedException();
		}
	}
}