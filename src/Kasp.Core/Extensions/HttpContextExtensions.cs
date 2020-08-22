using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Core.Extensions {
	public static class HttpContextExtensions {
		private static readonly RouteData EmptyRouteData = new RouteData();

		private static readonly ActionDescriptor EmptyActionDescriptor = new ActionDescriptor();

		public static Task WriteModelAsync<TModel>(this HttpContext context, TModel model) {
			var result = new ObjectResult(model) {DeclaredType = typeof(TModel)};

			return context.ExecuteResultAsync(result);
		}

		public static Task ExecuteResultAsync<TResult>(this HttpContext context, TResult result) where TResult : IActionResult {
			_ = context ?? throw new ArgumentNullException(nameof(context));
			_ = result ?? throw new ArgumentNullException(nameof(result));

			var executor = context.RequestServices.GetRequiredService<IActionResultExecutor<TResult>>();

			var routeData = context.GetRouteData() ?? EmptyRouteData;
			var actionContext = new ActionContext(context, routeData, EmptyActionDescriptor);

			return executor.ExecuteAsync(actionContext, result);
		}
	}
}