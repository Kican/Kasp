using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.Core.Tests.Tests {
	public class ApiControllerTest : IClassFixture<CustomWebAppFactory<Startup>> {
		public ApiControllerTest(CustomWebAppFactory<Startup> factory, ITestOutputHelper output) {
			_output = output;
			Client = factory.CreateClient();
		}

		private HttpClient Client { get; }
		private readonly ITestOutputHelper _output;

		[Fact]
		public async Task ApiController() {
			var response = await Client.GetAsync("api/values/get");
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}

		[Fact]
		public async Task PowerHeader() {
			var response = await Client.GetAsync("api/values/get");
			Assert.Equal("Kasp", response.Headers.GetValues("Powered-By").First());
		}

		[Theory]
		[InlineData("/")]
		[InlineData("/page/about-us")]
		public async Task IndexSpa(string path) {
			var response = await Client.GetAsync(path);
			Assert.Equal("index-html", await response.Content.ReadAsStringAsync());
		}
		
		[Theory]
		[InlineData("/api/values/get")]
		[InlineData("/panel")]
		public async Task IndexSpaExcept(string path) {
			var response = await Client.GetAsync(path);
			Assert.NotEqual("index-html", await response.Content.ReadAsStringAsync());
		}
	}
}