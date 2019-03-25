using System;
using Kasp.Core.Extensions;
using Kasp.Data.EF.Data;
using Kasp.Data.EF.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Data.EF.Extensions {
	public static class ServiceCollectionExtensions {
		public static KaspDbServiceBuilder AddDataBasePool<TDbContext>(this KaspServiceBuilder builder, Action<DbContextOptionsBuilder> optionsAction) where TDbContext : DbContext {
			builder.Services.AddDbContextPool<TDbContext>(optionsAction);
			return _AddDatabase<TDbContext>(builder);
		}
		
		public static KaspDbServiceBuilder AddDataBase<TDbContext>(this KaspServiceBuilder builder, Action<DbContextOptionsBuilder> optionsAction, ServiceLifetime lifetime = ServiceLifetime.Scoped)
			where TDbContext : DbContext {
			builder.Services.AddDbContext<TDbContext>(optionsAction, lifetime);
			return _AddDatabase<TDbContext>(builder);
		}

		public static void AddEntityHelper<T, TEntityHelper>(this DbContextOptionsBuilder builder) where TEntityHelper : EntityHelper<T> {
			EntityHelperFactory.Add<T, TEntityHelper>();
		}

		private static KaspDbServiceBuilder _AddDatabase<TDbContext>(KaspServiceBuilder builder) where TDbContext : DbContext {
//			builder.Services.AddScoped<DbContext, TDbContext>();
			return new KaspDbServiceBuilder(builder.Services, builder.Configuration, builder.MvcBuilder);
		}

		public static KaspDbServiceBuilder AddEFRepositories(this KaspDbServiceBuilder builder) {
			builder.Services.Scan(selector => {
				selector.FromApplicationDependencies()
					.AddClasses(x => x.AssignableTo(typeof(IEFBaseRepository<,>)))
					.AsSelfWithInterfaces()
					.WithScopedLifetime();
			});
			
			return builder;
		}
	}

	public class KaspDbServiceBuilder : KaspServiceBuilder {
		public KaspDbServiceBuilder(IServiceCollection services, IConfiguration configuration, IMvcBuilder mvcBuilder) : base(services, configuration, mvcBuilder) {
		}

		public KaspDbServiceBuilder(KaspDbServiceBuilder builder, IConfiguration configuration, IMvcBuilder mvcBuilder) : base(builder.Services, configuration, mvcBuilder) {
		}
	}
}