using Kasp.FormBuilder.Components.Elements;
using Kasp.FormBuilder.Components.Layouts;
using Kasp.FormBuilder.FluentValidation.Tests.Models;
using Kasp.FormBuilder.Services;
using Kasp.FormBuilder.Validators;
using Kasp.Test;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.FormBuilder.FluentValidation.Tests {
	public class ValidatorsTests : KClassFixtureWebApp<Startup> {
		public ValidatorsTests(ITestOutputHelper output, KWebAppFactory<Startup> factory) : base(output, factory) {
			FormBuilder = GetService<IFormBuilder>();
		}

		private IFormBuilder FormBuilder { get; }

		[Fact]
		public async void NotNullValidator() {
			var result = (LinearLayoutComponent) await FormBuilder.FromModel<Person>();
			var textField = (TextFieldComponent) result.Children.Find(x => x.Name == nameof(Person.Name));
			Assert.Contains(textField.Validators, validator => validator.Name == new RequiredValidator().Name);
		}

		[Fact]
		public async void MaximumLengthValidator() {
			var result = (LinearLayoutComponent) await FormBuilder.FromModel<Person>();
			var textField = (TextFieldComponent) result.Children.Find(x => x.Name == nameof(Person.Family));
			Assert.Contains(textField.Validators, validator => validator.Name == new MaxLengthValidator().Name);
		}

		[Fact]
		public async void LengthValidator() {
			var result = (LinearLayoutComponent) await FormBuilder.FromModel<Person>();
			var textField = (TextFieldComponent) result.Children.Find(x => x.Name == nameof(Person.Name));
			Assert.Contains(textField.Validators, validator => validator.Name == new RangeLengthValidator().Name);
		}
	}
}