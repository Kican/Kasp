using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Kasp.Core.Middlewares {
	public class KaspRequestHeaderMiddleware : IMiddleware {
		public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
			context.Response.Headers["Powered-By"] = "Kasp";
			await next(context);
		}
	}
}