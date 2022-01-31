using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.ObjectMapper.Extensions;

public static class AppBuilderExtensions {
	public static IApplicationBuilder UseObjectMapper(this IApplicationBuilder app) {
		ObjectMapperExtensions.ObjectMapper = app.ApplicationServices.CreateScope().ServiceProvider.GetService<IObjectMapper>();

		return app;
	}
}
