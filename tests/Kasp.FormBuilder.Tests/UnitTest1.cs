using Kasp.FormBuilder.Services;
using Kasp.Test;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.FormBuilder.Tests {
	public class UnitTest1 : KClassFixtureWebApp<Startup> {
		private IFormBuilder FormBuilder { get; }

		public UnitTest1(ITestOutputHelper output, KWebAppFactory<Startup> factory, IFormBuilder formBuilder) : base(output, factory) {
			FormBuilder = formBuilder;
		}

		[Fact]
		public void Test1() {
			Assert.True(1 == 2 - 1);
		}
	}
}