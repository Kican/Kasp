using System.Linq;

namespace Kasp.ObjectMapper.Extensions {
	public static class ObjectMapperExtensions {
		public static IObjectMapper ObjectMapper;

		public static TDestination MapTo<TDestination>(this object source) => ObjectMapper.MapTo<TDestination>(source);

		public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination) where TSource : class => ObjectMapper.MapTo(source, destination);

		public static IQueryable<TDestination> MapTo<TDestination>(this IQueryable source) => ObjectMapper.MapTo<TDestination>(source);
	}
}