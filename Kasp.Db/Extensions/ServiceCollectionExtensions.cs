using System;
using System.Linq;
using Kasp.Core.Extensions;
using Kasp.Db.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Db.Extensions {
	public static class ServiceCollectionExtensions {
		public static KaspDbServiceBuilder AddDataBasePool<TDbContext>(this KaspServiceBuilder builder, Action<DbContextOptionsBuilder> optionsAction) where TDbContext : DbContext {
			builder.Services.AddDbContextPool<TDbContext>(optionsAction);

			builder.Services.AddScoped<DbContext, TDbContext>();

			return new KaspDbServiceBuilder(builder.Services, builder.Configuration, typeof(TDbContext));
		}

		public static KaspDbServiceBuilder AddDataBase<TDbContext>(this KaspServiceBuilder builder, Action<DbContextOptionsBuilder> optionsAction) where TDbContext : DbContext {
			builder.Services.AddDbContext<TDbContext>(optionsAction);
			builder.Services.AddScoped<DbContext, TDbContext>();

			return new KaspDbServiceBuilder(builder.Services, builder.Configuration, typeof(TDbContext));
		}

		public static KaspDbServiceBuilder AddRepositories(this KaspDbServiceBuilder builder) {
			var repositoryTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
				.Where(x => typeof(BaseRepository<,,>).IsSubclassOfRawGeneric(x) && !x.IsInterface && !x.IsAbstract).ToList();

			repositoryTypes.ForEach(x => builder.Services.AddScoped(x));

			return builder;
		}
	}

	public class KaspDbServiceBuilder : KaspServiceBuilder {
		public Type DbContextType { get; }

		public KaspDbServiceBuilder(IServiceCollection services, IConfiguration configuration, Type dbContextType) : base(services, configuration) {
			DbContextType = dbContextType;
		}

		public KaspDbServiceBuilder(KaspDbServiceBuilder builder, IConfiguration configuration, Type dbContextType) : base(builder.Services, configuration) {
			DbContextType = dbContextType;
		}
	}
}