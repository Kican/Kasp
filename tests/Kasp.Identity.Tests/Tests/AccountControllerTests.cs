using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Kasp.Core.Tests;
using Kasp.Identity.Tests.Models.UserModels.XModels;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.Identity.Tests.Tests {
	public class AccountControllerTests : IClassFixture<KWebAppFactory<StartupIdentity>> {
		public AccountControllerTests(KWebAppFactory<StartupIdentity> factory, ITestOutputHelper output) {
			_client = factory.CreateDefaultClient();
			_output = output;
		}

		private readonly ITestOutputHelper _output;
		private readonly HttpClient _client;

		[Fact]
		public async Task Register() {
			var registerModel = new AppUserRegisterModel {Email = "son_games@yahoo.com", Password = "P2ssw0rd!$"};
			var response = await _client.PostAsJsonAsync("/api/account/register", registerModel);
			_output.WriteLine(await response.Content.ReadAsStringAsync());
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}
	}
}