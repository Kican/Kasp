using System.Linq;
using FluentValidation;
using FluentValidation.Internal;
using Kasp.FormBuilder.FluentValidation.Tests.Models;
using Kasp.FormBuilder.FluentValidation.Tests.Models.Validators;
using Kasp.Test;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.FormBuilder.FluentValidation.Tests {
	public class FluentCommunicateTests : KClassFixtureWebApp<Startup> {
		public FluentCommunicateTests(ITestOutputHelper output, KWebAppFactory<Startup> factory) : base(output, factory) {
		}

		[Fact]
		public void GetModelValidator() {
			var validatorType = typeof(IValidator<>).MakeGenericType(typeof(Person));

			var nameProp = typeof(Person).GetProperty(nameof(Person.Name));

			var validator = GetService(validatorType) as PersonValidator;

			var validators = validator.First(x=> (x as PropertyRule).PropertyName == "Name");

			Assert.IsType<PersonValidator>(validator);
		}


	}

}