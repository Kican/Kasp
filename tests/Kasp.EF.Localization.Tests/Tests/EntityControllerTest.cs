using System.Threading.Tasks;
using Kasp.Core.Tests;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.EF.Localization.Tests.Tests {
	public class EntityControllerTest : KClassFixtureWebApp<StartupDbLocalization> {

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

		public EntityControllerTest(ITestOutputHelper output, KWebAppFactory<StartupDbLocalization> factory) : base(output, factory) {
		}
	}
}