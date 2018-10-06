using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace Kasp.Tests {
	public class KWebAppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class {
		protected override IWebHostBuilder CreateWebHostBuilder() {
			return WebHost
				.CreateDefaultBuilder()
				.UseStartup<TStartup>();
		}

		protected override TestServer CreateServer(IWebHostBuilder builder) {
			//Fake Server we won't use...this is lame. Should be cleaner, or a utility class
			return new TestServer(CreateWebHostBuilder());
		}
	}
}