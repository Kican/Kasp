using AutoMapper;
using Kasp.Identity.Tests.Models.UserModels;
using Kasp.Identity.Tests.Models.UserModels.XModels;

namespace Kasp.Identity.Tests.Models {
	public class MapperProfile : Profile {
		public MapperProfile() {
			CreateMap<AppUserRegisterModel, AppUser>();
		}
	}
}