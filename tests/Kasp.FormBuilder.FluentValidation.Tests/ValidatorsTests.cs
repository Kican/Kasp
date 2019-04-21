using FluentValidation;
using Kasp.FormBuilder.FluentValidation.Tests.Models;
using Kasp.FormBuilder.Tests;
using Kasp.Test;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.FormBuilder.FluentValidation.Tests {
	public class ValidatorsTests : BaseModelValidatorTest<ValidatorTestModel, Startup> {
		public ValidatorsTests(ITestOutputHelper output, KWebAppFactory<Startup> factory) : base(output, factory) {
		}

		[Fact]
		public void T1() {
			var validator = GetService<IValidator<ValidatorTestModel>>();
			Assert.NotNull(validator);
		}
	}
}