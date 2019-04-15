using FluentValidation;
using Kasp.FormBuilder.FluentValidation.Tests.Models;
using Kasp.FormBuilder.Tests;
using Kasp.Test;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.FormBuilder.FluentValidation.Tests {
	public class ValidatorsTests : BaseModelValidatorTest<ValidatorTestModel> {
		public ValidatorsTests(ITestOutputHelper output, KWebAppFactory<FormBuilder.Tests.Startup> factory) : base(output, factory) {
			var valid = GetService<IValidator<ValidatorTestModel>>();
		}

		[Fact]
		public void T1() {
			Assert.True(true);
		}
	}
}