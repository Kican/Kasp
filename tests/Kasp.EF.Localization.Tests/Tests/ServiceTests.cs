using System.Net.Http;
using System.Threading.Tasks;
using Kasp.Core.Tests;
using Kasp.EF.Localization.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.EF.Localization.Tests.Tests {
	public class ServiceTests : KClassFixtureWebApp<StartupDbLocalization> {
		[Fact]
		public async Task GET_SUPPORTED_CULTURES() {
			var response = await Client.GetAsync("/api/lang/Cultures");
			var body = await response.Content.ReadAsAsync<string[]>();

			Assert.Equal(2, body.Length);
		}

		[Fact]
		public async Task LANG_REPOSITORY_UPDATE_CHECK() {
			var response = await Client.GetAsync("/api/lang/Cultures");
			var body = await response.Content.ReadAsAsync<string[]>();

			Assert.Equal(2, body.Length);
		}

		public ServiceTests(ITestOutputHelper output, KWebAppFactory<StartupDbLocalization> factory) : base(output, factory) {
		}
	}
}