using System;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Panel.EntityManager.Extensions {
	public static class ServiceCollectionExtensions {
		public static ServiceCollection AddEntityManager(this ServiceCollection services, Action<EntityManagerOptions> optionsAction) {
			var option = new EntityManagerOptions();
			optionsAction(option);

			return services;
		}
	}
}