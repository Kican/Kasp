using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Kasp.Core.Tests {
	public class CustomWebAppFactory<TStartUp> : WebApplicationFactory<TStartUp> where TStartUp : class {
		protected override IWebHostBuilder CreateWebHostBuilder() {
			return WebHost.CreateDefaultBuilder().UseStartup<Startup>();;
		}
	}
}