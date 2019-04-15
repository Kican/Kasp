using System.Linq;
using Mapster;

namespace Kasp.ObjectMapper.Mapster {
	public class Mapster : IObjectMapper<Mapster>, IObjectMapper {
		public TDestination MapTo<TDestination>(object source) => source.Adapt<TDestination>();

		public TDestination MapTo<TDestination>(object source, TDestination destination) {
			throw new System.NotSupportedException();
		}

		public IQueryable<TDestination> MapTo<TDestination>(IQueryable source) => source.ProjectToType<TDestination>();
	}
}