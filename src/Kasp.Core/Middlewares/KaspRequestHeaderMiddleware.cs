using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Kasp.Core.Middlewares {
	public class KaspRequestHeaderMiddleware {
		private readonly RequestDelegate _next;

		public KaspRequestHeaderMiddleware(RequestDelegate next) {
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext) {
			httpContext.Response.Headers["Powered-By"] = "Kasp";
			await _next(httpContext);
		}
	}
}