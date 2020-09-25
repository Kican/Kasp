using System.Threading.Tasks;
using Kasp.Test;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.HttpException.Tests {
	public class ExceptionTests : KClassFixtureWebApp<Startup> {
		public ExceptionTests(ITestOutputHelper output, KWebAppFactory<Startup> factory) : base(output, factory) {
		}

		[Fact]
		public async Task Sample1() {
			var response = await Client.GetAsync("/api/data/Get");

			Output.WriteLine(await response.Content.ReadAsStringAsync());
		}
		
		[Fact]
		public async Task WithData() {
			var response = await Client.GetAsync("/api/data/WithData");

			Output.WriteLine(await response.Content.ReadAsStringAsync());
		}
	}
}