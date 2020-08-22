using Kasp.Test;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.HttpException.Tests {
	public class ExceptionTests : KClassFixtureWebApp<Startup> {
		public ExceptionTests(ITestOutputHelper output, KWebAppFactory<Startup> factory) : base(output, factory) {
		}

		[Fact]
		public void Sample1() {
		}
	}
}