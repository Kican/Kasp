using System.Net;
using System.Threading.Tasks;
using Kasp.Core.Extensions;
using Kasp.Identity.Entities.UserEntities.XEntities;
using Kasp.Identity.Tests.Models.UserModels;
using Kasp.Identity.Tests.Models.UserModels.XModels;
using Kasp.Test;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
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

			Output.WriteLine(await response.Content.ReadAsStringAsync());

			var result = await response.Content.ReadAsAsync<BearerLoginResult>();

			Assert.Equal(3, result.access_token.Split(".").Length);
		}


		[Fact]
		public async Task XXX() {
			var userManager = Factory.Server.Host.Services.GetService<UserManager<AppUser>>();
			var user = new AppUser() {Email = "mo3in@asd.com", UserName = "mo3in@asd.com"};
			var result = await userManager.CreateAsync(user);

			var code = await userManager.GenerateUserTokenAsync(user, "Phone", "passwordless-auth");

			var verifyResult = await userManager.VerifyUserTokenAsync(user, "Phone", "passwordless-auth", code);
			Output.WriteLine(code);
			Assert.True(verifyResult && code.Length == 6);
		}


		public AccountControllerTests(ITestOutputHelper output, KWebAppFactory<StartupIdentity> factory) : base(output, factory) {
		}
	}

	public class BearerLoginResult {
		public string access_token { get; set; }
	}
}