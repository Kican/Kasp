using Kasp.Panel.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Kasp.Panel.Options.Extensions {
	public static class AppBuilderExtensions {
		// public static PanelRoutingOptionBuilder MapEntityManager(this PanelRoutingOptionBuilder builder, string endPoint = "api/discovery/options") {
		// 	builder.EndpointRouteBuilder.MapGet(endPoint, async context => {
		// 		var option = context.RequestServices.GetService<IOptions<EntityManagerOptions>>();
		// 		await new OkObjectResult(option.Value.Managers).ExecuteResultAsync(new ActionContext {HttpContext = context});
		// 	});
		// 	return builder;
		// }
	}
}