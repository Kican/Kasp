using Boxed.Mapping;
using Kasp.ObjectMapper.Benchmark.Models;

namespace Kasp.ObjectMapper.Benchmark.Mapping {
	public class BoxedMapper : IMapper<MapFrom, MapTo> {
		public void Map(MapFrom source, MapTo destination) {
			destination.BooleanTo = source.BooleanFrom;
			destination.DateTimeOffsetTo = source.DateTimeOffsetFrom;
			destination.IntegerTo = source.IntegerFrom;
			destination.LongTo = source.LongFrom;
			destination.StringTo = source.StringFrom;
		}
	}
}