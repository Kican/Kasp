using System.Threading.Tasks;

namespace Kasp.FormBuilder.Components {
	public interface IComponentResolver<TComponent> : IComponentResolver where TComponent : IComponent {
		new Task<TComponent> ResolveAsync(ComponentOptions options);
	}

	public interface IComponentResolver {
		Task<IComponent> ResolveAsync(ComponentOptions options);
	}
}