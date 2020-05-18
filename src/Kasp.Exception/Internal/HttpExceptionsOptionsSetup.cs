using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Kasp.Exception.Internal {
	public class HttpExceptionsOptionsSetup : IConfigureOptions<HttpExceptionOptions> {
		private readonly IServiceProvider _serviceProvider;

		public HttpExceptionsOptionsSetup(IServiceProvider serviceProvider) {
			_serviceProvider = serviceProvider;
		}

		public void Configure(HttpExceptionOptions options) {
			options.IncludeExceptionDetails ??= IncludeExceptionDetails;
			options.ShouldLogException ??= ShouldLogException;
		}

		private static bool IncludeExceptionDetails(HttpContext context) {
			return context.RequestServices.GetRequiredService<IWebHostEnvironment>().EnvironmentName == Environments.Development;
		}

		private static bool ShouldLogException(System.Exception ex) => true;
	}
}