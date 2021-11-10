using System.Linq;
using Mapster;

namespace Kasp.ObjectMapper.Mapster;

public class Mapster : IObjectMapper<Mapster>, IObjectMapper {
	public TDestination MapTo<TDestination>(object source) => source.Adapt<TDestination>();

	public TDestination MapTo<TSource, TDestination>(TSource source, TDestination destination) => source.Adapt(destination);

	public IQueryable<TDestination> MapTo<TDestination>(IQueryable source) => source.ProjectToType<TDestination>();
}
