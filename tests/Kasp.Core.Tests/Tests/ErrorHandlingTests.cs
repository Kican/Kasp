using System;
using System.Net;
using System.Threading.Tasks;
using Kasp.Core.Extensions;
using Kasp.Core.Middlewares;
using Kasp.Test;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.Core.Tests.Tests; 

public class ErrorHandlingTests : KClassFixtureWebApp<Startup> {
	public ErrorHandlingTests(ITestOutputHelper output, KWebAppFactory<Startup> factory) : base(output, factory) {
	}

	[Fact]
	public async Task EntityNotFound() {
		var response = await Client.GetAsync("api/error/notfound?id=10");
		Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

		var data = await response.Content.ReadAsAsync<ErrorDetails>();
		Assert.Equal(HttpStatusCode.NotFound, Enum.Parse<HttpStatusCode>(data.Status.ToString()));
	}
		
	[Fact]
	public async Task EntityExist() {
		var response = await Client.GetAsync("api/error/exist?id=10");
		Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

		var data = await response.Content.ReadAsAsync<ErrorDetails>();
		Assert.Equal(HttpStatusCode.BadRequest, Enum.Parse<HttpStatusCode>(data.Status.ToString()));
	}
		
	[Fact]
	public async Task InternalError() {
		var response = await Client.GetAsync("api/error/Internal");
		Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

		var data = await response.Content.ReadAsAsync<ErrorDetails>();
		Assert.Equal(HttpStatusCode.InternalServerError, Enum.Parse<HttpStatusCode>(data.Status.ToString()));
		Assert.Equal("salam", data.Message);
	}
}