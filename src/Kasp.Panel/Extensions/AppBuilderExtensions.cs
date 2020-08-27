using System;
using Kasp.Panel.Builder;
using Microsoft.AspNetCore.Routing;

namespace Kasp.Panel.Extensions {
	public static class AppBuilderExtensions {
		public static IEndpointRouteBuilder MapPanel(this IEndpointRouteBuilder builder, Action<PanelRoutingOptionBuilder> builderAction) {
			var option = new PanelRoutingOptionBuilder(builder);

			builderAction(option);
			return builder;
		}
	}
}