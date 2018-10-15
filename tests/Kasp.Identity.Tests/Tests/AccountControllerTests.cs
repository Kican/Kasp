using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Kasp.Identity.Entities.UserEntities.XEntities;
using Kasp.Identity.Tests.Models.UserModels.XModels;
using Kasp.Test;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.Identity.Tests.Tests {
	public class AccountControllerTests : KClassFixtureWebApp<StartupIdentity> {
		[Fact]
		public async Task REGISTER_AND_LOGIN_USER_PASS() {
			var registerModel = new AppUserRegisterModel {Email = "son_gamesw@yahoo.com", Password = "P2ssw0rd!$", Name = "mo3in"};
			var response = await Client.PostAsJsonAsync("/api/account/register", registerModel);
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);

			var loginModel = new LoginVM {Email = "son_gamesw@yahoo.com", Password = "P2ssw0rd!$"};
			response = await Client.PostAsJsonAsync("/api/account/Login", loginModel);

			var result = await response.Content.ReadAsAsync<BearerLoginResult>();

			Assert.Equal(3, result.access_token.Split(".").Length);
		}

		[Fact]
		public async Task REGISTER_AND_LOGIN_OTP() {
			var response = await Client.PostAsJsonAsync("/api/account/PhoneRequest", new {Phone = "00000000"});
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);

			response = await Client.PostAsJsonAsync("/api/account/LoginOtp", new {Phone = "00000000", AuthOtpSmsSender.Code});
			var result = await response.Content.ReadAsAsync<BearerLoginResult>();

			Assert.Equal(3, result.access_token.Split(".").Length);
		}

		public AccountControllerTests(ITestOutputHelper output, KWebAppFactory<StartupIdentity> factory) : base(output, factory) {
		}
	}

	public class BearerLoginResult {
		public string access_token { get; set; }
	}
}