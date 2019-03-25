using Kasp.ObjectMapper.Extensions;
using Kasp.ObjectMapper.Tests.Models;
using Xunit;

namespace Kasp.ObjectMapper.Tests {
	public class UnitTest1 {
		[Fact]
		public void Test1() {
			var user = new User();
			var userVm = user.MapTo<UserVm>();
		}
	}
}