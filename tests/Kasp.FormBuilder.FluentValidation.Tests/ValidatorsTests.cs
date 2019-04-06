using System.Threading.Tasks;
using Kasp.FormBuilder.Components;
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

		private async Task<T> GetFieldAsync<T>(string name) where T : IComponent {
			var result = (LinearLayoutComponent) await FormBuilder.FromModel<Person>();
			return (T) result.Children.Find(x => x.Name == name);
		}

		[Fact]
		public async void NotNullValidator() {
			var field = await GetFieldAsync<TextFieldComponent>(nameof(Person.Name));
			Assert.Contains(field.Validators, validator => validator.Name == new RequiredValidator().Name);
		}

		[Fact]
		public async void MaximumLengthValidator() {
			var field = await GetFieldAsync<TextFieldComponent>(nameof(Person.Family));
			Assert.Contains(field.Validators, validator => validator.Name == new MaxLengthValidator().Name);
		}

		[Fact]
		public async void LengthValidator() {
			var field = await GetFieldAsync<TextFieldComponent>(nameof(Person.Name));
			Assert.Contains(field.Validators, validator => validator.Name == new RangeLengthValidator().Name);
		}

		[Fact]
		public async void MvcRequired_Email_MaxLength() {
			var field = await GetFieldAsync<TextFieldComponent>(nameof(Person.Email));
			Assert.Contains(field.Validators, validator => validator.Name == new MaxLengthValidator().Name);
			Assert.Contains(field.Validators, validator => validator.Name == new RequiredValidator().Name);
			Assert.Contains(field.Validators, validator => validator.Name == new EmailValidator().Name);
		}
	}
}