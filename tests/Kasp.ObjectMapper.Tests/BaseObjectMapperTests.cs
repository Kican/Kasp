using Kasp.ObjectMapper.Tests.Models;
using Kasp.Test;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.ObjectMapper.Tests {
	public abstract class BaseObjectMapperTests<TStartup> : KClassFixtureWebApp<TStartup> where TStartup : class {
		protected BaseObjectMapperTests(ITestOutputHelper output, KWebAppFactory<TStartup> factory) : base(output, factory) {
			ObjectMapper = GetService<IObjectMapper>();
		}

		public IObjectMapper ObjectMapper { get; }

		User _user = new User {Id = 10, Name = "mo3in", Family = "hente"};

		[Fact]
		public void Map() {
			var userVm = ObjectMapper.MapTo<UserVm>(_user);
			Assert.True(userVm.Id == _user.Id && userVm.FullName == _user.Name + " " + _user.Family);
		}

		[Fact]
		public void PatchMap() {
			var user = new User {Id = 2, Name = "mo3in", Family = "hente", Email = "moein.h@f.com"};
			var userVm = new UserUpdateModel {Id = 2, Name = "reza", Family = "sadeghi"};

			var result = ObjectMapper.MapTo(userVm, user);
			Assert.True(result.Id == user.Id && result.Name == userVm.Name && result.Email == user.Email && result.Family == userVm.Family);
		}
	}
}