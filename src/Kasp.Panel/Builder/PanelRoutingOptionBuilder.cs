using Microsoft.AspNetCore.Routing;

namespace Kasp.Panel.Builder {
	public class PanelRoutingOptionBuilder {
		public PanelRoutingOptionBuilder(IEndpointRouteBuilder endpointRouteBuilder) {
			EndpointRouteBuilder = endpointRouteBuilder;
		}

		public IEndpointRouteBuilder EndpointRouteBuilder { get; }
	}
}