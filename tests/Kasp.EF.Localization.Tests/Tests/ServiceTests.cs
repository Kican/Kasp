using System.Net.Http;
using System.Threading.Tasks;
using Kasp.Test;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.EF.Localization.Tests.Tests {
	[Collection("1")]
	public class ServiceTests : KClassFixtureWebApp<StartupDbLocalization> {
		[Fact]
		public async Task GET_SUPPORTED_CULTURES() {
			var response = await Client.GetAsync("/api/lang/Cultures");
			var body = await response.Content.ReadAsAsync<string[]>();

			Assert.Equal(2, body.Length);
		}

		[Theory]
		[InlineData("fa-IR")]
		[InlineData("en-US")]
		public async Task REQUEST_CULTURE_FEATURE(string culture) {
			var response = await Client.GetStringAsync("/api/lang/CurrentCulture?culture=" + culture);
			Assert.Equal(culture, response);
		}

		[Theory]
		[InlineData("fa-IR")]
		[InlineData("en-US")]
		public async Task CultureInfo(string culture) {
			var response = await Client.GetStringAsync("/api/lang/Culture?culture=" + culture);
			Assert.Equal(culture, response);
		}

		public ServiceTests(ITestOutputHelper output, KWebAppFactory<StartupDbLocalization> factory) : base(output, factory) {
		}
	}
}