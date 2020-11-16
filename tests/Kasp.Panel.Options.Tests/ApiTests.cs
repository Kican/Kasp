using System.Threading.Tasks;
using Kasp.Test;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.Panel.Options.Tests {
	public class ApiTests : KClassFixtureWebApp<Startup> {
		public ApiTests(ITestOutputHelper output, KWebAppFactory<Startup> factory) : base(output, factory) {
		}

		[Fact]
		public async Task GetListOfAll() {
			var response = await Client.GetStringAsync("/api/panel/options");

			Output.WriteLine(response);
		}

		[Fact]
		public async Task GetValue() {
			var response = await Client.GetStringAsync("/api/panel/options/kasp.panel.options.tests.globalsiteoption");

			Output.WriteLine(response);
		}
	}
}
