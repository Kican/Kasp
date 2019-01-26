using System;
using Kasp.FormBuilder.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.FormBuilder.Extensions {
	public static class ServiceCollectionExtensions {
		public static IServiceCollection AddFormBuilder(this IServiceCollection services) {
			services.AddTransient<IFormBuilder, Services.FormBuilder>();

			return services;
		}

		public static IServiceCollection AddFormBuilder(this IServiceCollection services, Action<FormBuilderOptions> setupAction) {
			services.AddFormBuilder();
			services.Configure<FormBuilderOptions>(setupAction);

			return services;
		}
	}
}