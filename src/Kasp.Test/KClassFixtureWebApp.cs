using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.Test {
	public abstract class KClassFixtureWebApp<T> : IClassFixture<KWebAppFactory<T>> where T : class {
		protected readonly ITestOutputHelper Output;
		protected readonly KWebAppFactory<T> Factory;
		protected readonly HttpClient Client;
		protected IServiceProvider ServiceProvider { get; }

		protected KClassFixtureWebApp(ITestOutputHelper output, KWebAppFactory<T> factory) {
			Output = output;
			Factory = factory;
			Client = factory.CreateDefaultClient();

			ServiceProvider = factory.Server.Host.Services;
		}

		protected TService GetService<TService>() => ServiceProvider.GetService<TService>();

		protected TService GetRequiredService<TService>() => ServiceProvider.GetRequiredService<TService>();
	}
}