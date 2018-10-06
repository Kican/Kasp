using System.Net.Http;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.Test {
	public abstract class KClassFixtureWebApp<T> : IClassFixture<KWebAppFactory<T>> where T : class {
		protected readonly ITestOutputHelper Output;
		protected readonly KWebAppFactory<T> Factory;
		protected readonly HttpClient Client;

		protected KClassFixtureWebApp(ITestOutputHelper output, KWebAppFactory<T> factory) {
			Output = output;
			Factory = factory;
			Client = factory.CreateDefaultClient();
		}
	}
}