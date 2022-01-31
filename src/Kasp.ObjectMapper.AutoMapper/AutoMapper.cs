using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Kasp.ObjectMapper.AutoMapper;

public class AutoMapper : IObjectMapper<AutoMapper>, IObjectMapper {
	public AutoMapper(IMapper mapper) {
		Mapper = mapper;
	}

	private IMapper Mapper { get; }

	public TDestination MapTo<TDestination>(object source) => Mapper.Map<TDestination>(source);
	public TDestination MapTo<TSource, TDestination>(TSource source, TDestination destination) => Mapper.Map(source, destination);
	public IQueryable<TDestination> MapTo<TDestination>(IQueryable source) => source.ProjectTo<TDestination>(Mapper.ConfigurationProvider);
}
