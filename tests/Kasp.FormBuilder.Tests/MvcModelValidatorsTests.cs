using Kasp.FormBuilder.Tests.Models;
using Kasp.Test;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.FormBuilder.Tests {
	public class MvcModelValidatorsTests : BaseModelValidatorTest<MvcAttributeValidatorTestModel> {
		public MvcModelValidatorsTests(ITestOutputHelper output, KWebAppFactory<Startup> factory) : base(output, factory) {
		}

		[Fact]
		public void T1() {
			Assert.True(true);
		}
	}
}