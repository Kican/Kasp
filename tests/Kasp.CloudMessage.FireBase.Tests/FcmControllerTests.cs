using System.Net.Http;
using System.Threading.Tasks;
using Kasp.CloudMessage.FireBase.Models.UserTokenModels.XModels;
using Kasp.Test;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.CloudMessage.FireBase.Tests {
	public class FcmControllerTests : KClassFixtureWebApp<Startup> {
		public FcmControllerTests(ITestOutputHelper output, KWebAppFactory<Startup> factory) : base(output, factory) {
		}

		[Fact]
		public async Task ADD_USER_TOKEN() {
//			var model = new FcmUserTokenEditModel {
//				Token = "test"
//			};
//
//			var result = await Client.PostAsJsonAsync("/api/Fcm/AddUserToken", model);
//			Assert.True(result.IsSuccessStatusCode);
		}
	}
}