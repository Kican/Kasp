using System.Threading.Tasks;
using Kasp.Test;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.Panel.EntityManager.Tests {
	public class EndPointTests : KClassFixtureWebApp<Startup> {
		public EndPointTests(ITestOutputHelper output, KWebAppFactory<Startup> factory) : base(output, factory) {
		}

		[Fact]
		public async Task CheckEndPoint() {
			// var client = Factory.WithWebHostBuilder(builder => {
			// 	builder.ConfigureServices(services => {
			// 		services.AddControllers();
			// 		services.AddHttpContextAccessor();
			// 		services.AddEntityManager();
			// 	});
			//
			// 	builder.Configure(app => {
			// 		app.UseRouting();
			//
			// 		app.UseEndpoints(routes => { routes.MapEntityManager(); });
			// 	});
			// });
			var response = await Client.GetAsync("/api/discovery/entity-managers");
			Output.WriteLine(await response.Content.ReadAsStringAsync());
		}
	}
}