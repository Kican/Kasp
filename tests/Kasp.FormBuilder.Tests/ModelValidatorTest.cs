using System.Linq;
using Kasp.FormBuilder.Components.Elements;
using Kasp.FormBuilder.Components.Layouts;
using Kasp.FormBuilder.Extensions;
using Kasp.FormBuilder.Services;
using Kasp.FormBuilder.Tests.Models;
using Kasp.FormBuilder.Validators;
using Kasp.Test;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.FormBuilder.Tests {
	public class ModelValidatorTest : KClassFixtureWebApp<Startup> {
		private IFormBuilder FormBuilder { get; }
		private LinearLayoutComponent Form;

		public ModelValidatorTest(ITestOutputHelper output, KWebAppFactory<Startup> factory) : base(output, factory) {
			FormBuilder = GetService<IFormBuilder>();
			Form = FormBuilder.FromModel<TestModelValidators>().Result as LinearLayoutComponent;
		}

		[Fact]
		public void Required() {
			var field = Form.GetChild<TextFieldComponent>(nameof(TestModelValidators.Required));
			Assert.True(field.Validators.Any(x => x.Name == "required"));
		}

		[Fact]
		public void MaxLength() {
			// todo: must check max value
			var field = Form.GetChild<TextFieldComponent>(nameof(TestModelValidators.MaxLength));
			Assert.True(field.Validators.Any(x => x.GetType() == typeof(MaxLengthValidator)));
		}
	}
}