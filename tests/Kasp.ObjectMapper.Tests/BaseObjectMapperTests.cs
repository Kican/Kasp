using System.Collections.Generic;
using Kasp.ObjectMapper.Extensions;
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

		public List<User> _users = new List<User> {new User {Id = 10, Name = "mo3in", Family = "hente"}};


		[Fact]
		public void Map() {
			var user = _users[0];
			var userVm = ObjectMapper.MapTo<UserVm>(user);
			Assert.True(userVm.Id == user.Id && userVm.FullName == user.Name + " " + user.Family);
		}


		[Fact]
		public void MapExtension() {
			var user = _users[0];
			var userVm = user.MapTo<UserVm>();
			Assert.True(userVm.Id == user.Id && userVm.FullName == user.Name + " " + user.Family);
		}

		[Fact]
		public void PatchMap() {
			var user = _users[0];
			var userVm = new UserUpdateModel {Id = 2, Name = "reza", Family = "sadeghi"};

			var result = ObjectMapper.MapTo(userVm, user);
			Assert.True(result.Id == user.Id && result.Name == userVm.Name && result.Email == user.Email && result.Family == userVm.Family);
		}
	}
}