using System.Linq;

namespace Kasp.ObjectMapper;

public interface IObjectMapper {
	TDestination MapTo<TDestination>(object source);
	TDestination MapTo<TSource, TDestination>(TSource source, TDestination destination);

	IQueryable<TDestination> MapTo<TDestination>(IQueryable source);
}

public interface IObjectMapper<T> where T : IObjectMapper {
}
