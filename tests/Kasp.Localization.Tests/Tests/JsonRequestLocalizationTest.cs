using System.Threading.Tasks;
using Kasp.Tests;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.Localization.Tests.Tests {
	public class JsonRequestLocalizationTest : KClassFixtureWebApp<StartupLocalizationJson> {
		[Theory]
		[InlineData("fa-IR", "سلام")]
		[InlineData("en-US", "Hello")]
		public async Task QueryLocalization(string culture, string result) {
			var response = await Factory.CreateDefaultClient().GetStringAsync($"/api/localization/index?culture={culture}&ui-culture={culture}");
			Assert.Equal(result, response);
		}

		[Theory]
		[InlineData("fa-IR", "سلام")]
		[InlineData("en-US", "Hello")]
		public async Task HeaderLocalization(string culture, string result) {
			var client = Factory.CreateDefaultClient();
			client.DefaultRequestHeaders.Add("accept-language", culture);
			var response = await client.GetStringAsync("/api/localization/index");
			Assert.Equal(result, response);
		}

		[Theory]
		[InlineData("fa-IR", "سلام")]
		[InlineData("en-US", "Hello")]
		public async Task NotExistKey(string culture, string result) {
			var client = Factory.CreateDefaultClient();
			client.DefaultRequestHeaders.Add("accept-language", culture);
			var response = await client.GetStringAsync("/api/localization/NotExistKey");
			Assert.Equal("Not-Exist", response);
		}

		public JsonRequestLocalizationTest(ITestOutputHelper output, KWebAppFactory<StartupLocalizationJson> factory) : base(output, factory) {
		}
	}
}