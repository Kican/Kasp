using System.Threading.Tasks;
using Kasp.Core.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kasp.Exception.Internal {
	public class KaspExceptionHandlerOptions : ExceptionHandlerOptions {
		public KaspExceptionHandlerOptions() {
			ExceptionHandler = Handler;
		}

		private async Task Handler(HttpContext context) {
			var exceptionHandler = context.Features.Get<IExceptionHandlerPathFeature>();

			var option = context.RequestServices.GetService<IOptions<HttpExceptionOptions>>().Value;
			var logger = context.RequestServices.GetService<ILogger>();

			if (option.ShouldLogException(exceptionHandler.Error))
				logger.LogError(exceptionHandler.Error, "unhandled exception");

			await context.ExecuteResultAsync(option.MapToAction(exceptionHandler.Error, context));
		}
	}
}