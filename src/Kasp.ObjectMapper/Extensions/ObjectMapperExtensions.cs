using System.Linq;

namespace Kasp.ObjectMapper.Extensions {
	public static class ObjectMapperExtensions {
//		public static TDestination MapTo<TDestination>(this object source)  {
//			return default;
//		}
//
//		public static TDestination MapTo<TDestination>(this object source, TDestination destination) {
//			return default;
//		}
		
		public static IQueryable<TDestination> MapTo<TDestination>(this IQueryable source) {
			return default;
		}
	}
}