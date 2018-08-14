using System.Collections.Generic;
using System.IO;
using System.Linq;
using Kasp.Core.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Kasp.Core {
	public static class KaspApplicationBuilderExtensions {
		public static KaspAppBuilder UseKasp(this IApplicationBuilder app) {
			app.UseMiddleware<KaspRequestHeaderMiddleware>();
			return new KaspAppBuilder(app);
		}

		public static KaspAppBuilder UseIndexSpa(this KaspAppBuilder app, string[] ignorePaths = null) {
			var ignoreList = new List<string>();
			ignoreList.AddRange(new[] {"/admin", "/api"});
			
			if (ignorePaths != null)
				ignoreList.AddRange(ignorePaths);

			app.ApplicationBuilder.Use(async (context, next) => {
				await next();

				if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value) && !ignoreList.Any(x => context.Request.Path.Value.StartsWith(x))) {
					context.Request.Path = "/index.html";
					await next();
				}
			});

			return app;
		}
	}

	public class KaspAppBuilder {
		public KaspAppBuilder(IApplicationBuilder applicationBuilder) {
			ApplicationBuilder = applicationBuilder;
		}

		public IApplicationBuilder ApplicationBuilder { get; }
	}
}