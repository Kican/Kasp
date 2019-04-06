using System;
using Kasp.FormBuilder.Components;
using Kasp.FormBuilder.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.FormBuilder.Extensions {
	public static class ServiceCollectionExtensions {
		public static IServiceCollection AddFormBuilder(this IServiceCollection services) {
			services.AddFormBuilder(options => { });
			return services;
		}

		public static IServiceCollection AddFormBuilder(this IServiceCollection services, Action<FormBuilderOptions> setupAction) {
			services.AddTransient<IFormBuilder, Services.FormBuilder>();
			services.AddTransient<IValidatorResolver, MvcValidatorResolver>();

			var options = new FormBuilderOptions(services);
			setupAction(options);
			services.AddSingleton(options);

			foreach (var handler in options.ComponentHandlers)
				services.AddTransient(handler.GetResolverType());

			return services;
		}
	}
}