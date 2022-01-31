using System.Threading.Tasks;
using Kasp.Core.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kasp.HttpException.Internal; 

public class KaspExceptionHandlerOptions : ExceptionHandlerOptions {
	public KaspExceptionHandlerOptions() {
		ExceptionHandler = Handler;
	}

	private async Task Handler(HttpContext context) {
		var exceptionHandler = context.Features.Get<IExceptionHandlerPathFeature>();

		var option = context.RequestServices.GetService<IOptions<HttpExceptionOptions>>().Value;
		var mapper = context.RequestServices.GetService<IExceptionMapper>();

		if (option.ShouldLogException(exceptionHandler.Error)) {
			var logger = context.RequestServices.GetService<ILogger<KaspExceptionHandlerOptions>>();
			logger.LogError(exceptionHandler.Error, "unhandled exception");
		}

		await mapper.Map(exceptionHandler.Error, context).ExecuteResultAsync(new ActionContext {HttpContext = context});
	}
}