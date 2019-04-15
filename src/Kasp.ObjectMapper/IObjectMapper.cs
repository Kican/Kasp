using System.Linq;

namespace Kasp.ObjectMapper {
	public interface IObjectMapper {
		TDestination MapTo<TDestination>(object source);
		TDestination MapTo<TDestination>(object source, TDestination destination);

		TDestination MapTo<TDestination>(IQueryable source);
	}
}