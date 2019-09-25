using System.Net.Http;
using System.Threading.Tasks;
using Kasp.Data.Test.Controllers;
using Kasp.Test;
using Xunit;
using Xunit.Abstractions;
using System.Text.Json;
using Kasp.Core.Extensions;

namespace Kasp.Data.Test {
	public class PageControllerTest : KClassFixtureWebApp<Startup> {
		public PageControllerTest(ITestOutputHelper output, KWebAppFactory<Startup> factory) : base(output, factory) {
		}

		[Theory]
		[InlineData(1, 4)]
		[InlineData(2, 10)]
		public async Task Test1(int page, int count) {
			var response = await Client.GetAsync($"/api/page/PageBind?page={page}&count={count}");
			var result = await response.Content.ReadAsAsync<Pageable>();
			Assert.True(result.Page == page && result.Count == count);
		}
	}
}