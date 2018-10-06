using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Kasp.Identity.Tests.Models.UserModels.XModels;
using Kasp.Test;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.Identity.Tests.Tests {
	public class AccountControllerTests : KClassFixtureWebApp<StartupIdentity> {
		[Fact]
		public async Task Register() {
			var registerModel = new AppUserRegisterModel {Email = "son_gamesw@yahoo.com", Password = "P2ssw0rd!$"};
			var response = await Client.PostAsJsonAsync("/api/account/register", registerModel);
			Output.WriteLine(await response.Content.ReadAsStringAsync());
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}

		public AccountControllerTests(ITestOutputHelper output, KWebAppFactory<StartupIdentity> factory) : base(output, factory) {
		}
	}
}