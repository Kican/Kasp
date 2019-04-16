using System;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.ObjectMapper.Extensions {
	public static class ServiceCollectionExtensions {
		public static IServiceCollection AddObjectMapper<TMapper>(this IServiceCollection builder) where TMapper : class, IObjectMapper<TMapper>, IObjectMapper {
			builder.AddTransient<IObjectMapper, TMapper>();
			builder.AddTransient<IObjectMapper<TMapper>, TMapper>();

			return builder;
		}
	}
}