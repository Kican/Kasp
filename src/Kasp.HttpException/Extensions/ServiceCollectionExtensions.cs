using System;
using Kasp.HttpException.Internal;
using Kasp.HttpException.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.HttpException.Extensions {
	public static class ServiceCollectionExtensions {
		public static IMvcCoreBuilder AddHttpExceptions(this IMvcCoreBuilder builder, Action<HttpExceptionOptions> configureOptions = null) {
			builder.Services.AddHttpExceptions(configureOptions);
			builder.ConfigureApiBehaviorOptions(ConfigureApiBehaviorOptions);

			return builder;
		}

		public static IMvcBuilder AddHttpExceptions(this IMvcBuilder builder, Action<HttpExceptionOptions> configureOptions = null) {
			builder.Services.AddHttpExceptions(configureOptions);
			builder.ConfigureApiBehaviorOptions(ConfigureApiBehaviorOptions);

			return builder;
		}

		private static IServiceCollection AddHttpExceptions(this IServiceCollection services, Action<HttpExceptionOptions> configureOptions = null) {
			services.AddOptions();
			if (configureOptions != null)
				services.Configure(configureOptions);

			services.ConfigureOptions<HttpExceptionsOptionsSetup>();
			services.AddScoped<IExceptionMapper, ProblemDetailMapper>();

			return services;
		}

		private static void ConfigureApiBehaviorOptions(ApiBehaviorOptions options) {
			options.SuppressMapClientErrors = true;
			options.SuppressModelStateInvalidFilter = false;
			// options.InvalidModelStateResponseFactory = HandleInvalidModelStateResponse;
		}

		// private static IActionResult HandleInvalidModelStateResponse(ActionContext actionContext) {
		// 	// Should we be throwing an exception here?
		// 	throw new BadRequestException(actionContext.ModelState.ToDictionary());
		// 	// The other options is to map the exception here are return a ProblemDetailsResult
		// 	//var httpExceptionsOptions = actionContext.HttpContext.RequestServices.GetRequiredService<IOptions<HttpExceptionsOptions>>();
		// 	//httpExceptionsOptions.Value.TryMap(ex, actionContext.HttpContext, out var problemDetails);
		// 	//return new ProblemDetailsResult(problemDetails);
		// }
	}
}