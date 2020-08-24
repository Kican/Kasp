using System;
using Kasp.Panel.EntityManager.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Panel.EntityManager.Extensions {
	public static class ServiceCollectionExtensions {
		public static IServiceCollection AddEntityManager(this IServiceCollection services, Action<IEntityManagerBuilder> optionsAction) {
			var option = new EntityManagerBuilder();

			optionsAction.Invoke(option);

			services.Configure<EntityManagerOptions>(options => options.Managers = option.Managers);

			return services;
		}
	}
}