using System.Threading.Tasks;
using Kasp.Tests;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.Localization.Tests.Tests {
	public class LocalizationControllerTest :KClassFixtureWebApp<StartupLocalizationResX> {
	
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

		public LocalizationControllerTest(ITestOutputHelper output, KWebAppFactory<StartupLocalizationResX> factory) : base(output, factory) {
		}
	}
}