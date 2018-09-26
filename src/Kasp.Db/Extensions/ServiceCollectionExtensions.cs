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

			return new KaspDbServiceBuilder(builder.Services, builder.Configuration, builder.MvcBuilder);
		}

		public static KaspDbServiceBuilder AddDataBase<TDbContext>(this KaspServiceBuilder builder, Action<DbContextOptionsBuilder> optionsAction) where TDbContext : DbContext {
			builder.Services.AddDbContext<TDbContext>(optionsAction);
			builder.Services.AddScoped<DbContext, TDbContext>();

			return new KaspDbServiceBuilder(builder.Services, builder.Configuration, builder.MvcBuilder);
		}

		public static KaspDbServiceBuilder AddRepositories(this KaspDbServiceBuilder builder) {
			var repositoryTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
				.Where(x => typeof(BaseRepository<,,>).IsSubclassOfRawGeneric(x) && !x.IsInterface && !x.IsAbstract).ToList();

			repositoryTypes.ForEach(x => builder.Services.AddScoped(x));

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