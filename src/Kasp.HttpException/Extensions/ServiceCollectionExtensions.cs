using System;
using Kasp.HttpException.Internal;
using Kasp.HttpException.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.HttpException.Extensions; 

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

		services.Configure<ApiBehaviorOptions>(options => {
			options.InvalidModelStateResponseFactory = context => new UnprocessableEntityObjectResult(new ValidationProblemDetails(context.ModelState));
		});

		services.ConfigureOptions<HttpExceptionsOptionsSetup>();
		services.AddScoped<IExceptionMapper, ProblemDetailMapper>();

		return services;
	}

	private static void ConfigureApiBehaviorOptions(ApiBehaviorOptions options) {
		options.SuppressMapClientErrors = true;
		options.SuppressModelStateInvalidFilter = false;
		// options.InvalidModelStateResponseFactory = HandleInvalidModelStateResponse;
	}
}