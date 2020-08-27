using System;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Panel.Options.Extensions {
	public static class ServiceCollectionExtensions {
		public static IServiceCollection AddKaspOptions(this IServiceCollection services, Action<IEntityManagerBuilder> optionsAction) {
			var option = new EntityManagerBuilder();

			optionsAction.Invoke(option);

			services.Configure<EntityManagerOptions>(options => options.Managers = option.Managers);

			return services;
		}
	}
}