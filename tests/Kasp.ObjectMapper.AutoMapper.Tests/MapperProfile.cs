using AutoMapper;
using Kasp.ObjectMapper.Tests.Models;

namespace Kasp.ObjectMapper.AutoMapper.Tests {
	public class MapperProfile : Profile {
		public MapperProfile() {
			CreateMap<User, UserVm>()
				.ForMember(x => x.FullName, y => y.MapFrom(z => z.Name + " " + z.Family));
		}
	}
}