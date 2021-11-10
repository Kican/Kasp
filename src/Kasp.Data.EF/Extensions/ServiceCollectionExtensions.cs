using Kasp.Data.EF.Data;
using Kasp.Data.EF.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Data.EF.Extensions; 

public static class ServiceCollectionExtensions {
	public static void AddEntityHelper<T, TEntityHelper>(this DbContextOptionsBuilder builder) where TEntityHelper : EntityHelper<T> {
		EntityHelperFactory.Add<T, TEntityHelper>();
	}

	public static IServiceCollection AddEFRepositories(this IServiceCollection builder) {
		builder.Scan(selector => {
			selector.FromApplicationDependencies()
				.AddClasses(x => x.AssignableTo(typeof(IEFBaseRepository<,>)))
				.AsSelfWithInterfaces()
				.WithScopedLifetime();
		});
			
		return builder;
	}
}