using System.Threading.Tasks;
using Kasp.Core.Tests;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.Localization.Test.Tests {
	public class JsonRequestLocalizationTest : IClassFixture<KWebAppFactory<StartupLocalizationJson>> {
		public JsonRequestLocalizationTest(KWebAppFactory<StartupLocalizationJson> factory, ITestOutputHelper output) {
			_factory = factory;
			_output = output;
		}

		private readonly ITestOutputHelper _output;
		private readonly KWebAppFactory<StartupLocalizationJson> _factory;

		[Theory]
		[InlineData("fa-IR", "سلام")]
		[InlineData("en-US", "Hello")]
		public async Task QueryLocalization(string culture, string result) {
			var response = await _factory.CreateDefaultClient().GetStringAsync($"/api/localization/index?culture={culture}&ui-culture={culture}");
			Assert.Equal(result, response);
		}

		[Theory]
		[InlineData("fa-IR", "سلام")]
		[InlineData("en-US", "Hello")]
		public async Task HeaderLocalization(string culture, string result) {
			var client = _factory.CreateDefaultClient();
			client.DefaultRequestHeaders.Add("accept-language", culture);
			var response = await client.GetStringAsync("/api/localization/index");
			Assert.Equal(result, response);
		}

		[Theory]
		[InlineData("fa-IR", "سلام")]
		[InlineData("en-US", "Hello")]
		public async Task NotExistKey(string culture, string result) {
			var client = _factory.CreateDefaultClient();
			client.DefaultRequestHeaders.Add("accept-language", culture);
			var response = await client.GetStringAsync("/api/localization/NotExistKey");
			Assert.Equal("Not-Exist", response);
		}
	}
}