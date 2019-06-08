using System;
using System.Collections.Generic;
using System.Linq;
using Kasp.FormBuilder.Components;
using Kasp.FormBuilder.Components.Elements;
using Kasp.FormBuilder.Components.Layouts;
using Kasp.FormBuilder.Models;
using Kasp.FormBuilder.Services;
using Kasp.FormBuilder.Tests.Models;
using Kasp.FormBuilder.Validators;
using Kasp.Test;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.FormBuilder.Tests {
	public abstract class BaseModelValidatorTest<TModel, TStartup> : KClassFixtureWebApp<TStartup> where TModel : class, ITestValidatorModel where TStartup : class {
		private IFormBuilder FormBuilder { get; }
		private LinearLayoutComponent Form;

		protected BaseModelValidatorTest(ITestOutputHelper output, KWebAppFactory<TStartup> factory) : base(output, factory) {
			FormBuilder = GetService<IFormBuilder>();
			Form = FormBuilder.FromModel<TModel>().Result as LinearLayoutComponent;
		}

		protected void AssertValidator<TValidator>(IEnumerable<IValidator> validators, params Func<TValidator, bool>[] conditions) where TValidator : class, IValidator, new() {
			var validator = validators.FirstOrDefault(x => x.Name == new TValidator().Name);
			Assert.NotNull(validator);

			foreach (var condition in conditions)
				Assert.True(condition(validator as TValidator));
		}

		private T GetField<T>(string name) where T : IComponent => (T) Form.Children.Find(x => x.Name == name);

		[Fact]
		public virtual void Required() {
			var field = GetField<TextFieldComponent>(nameof(ITestValidatorModel.Required));
			AssertValidator<RequiredValidator>(field.Validators);
		}

		[Fact]
		public virtual void MaxLength() {
			var field = GetField<TextFieldComponent>(nameof(ITestValidatorModel.MaxLength));
			AssertValidator<MaxLengthValidator>(field.Validators, validator => validator.Length == 100);
		}

		[Fact]
		public virtual void MinLength() {
			var field = GetField<TextFieldComponent>(nameof(ITestValidatorModel.MinLength));
			AssertValidator<MinLengthValidator>(field.Validators, validator => validator.Length == 10);
		}

		[Fact]
		public virtual void RangeLength() {
			var field = GetField<TextFieldComponent>(nameof(ITestValidatorModel.RangeLength));
			AssertValidator<RangeLengthValidator>(field.Validators, validator => validator.Max == 100 && validator.Min == 10);
		}


		[Fact]
		public virtual void Max() {
			var field = GetField<TextFieldComponent>(nameof(ITestValidatorModel.Max));
			AssertValidator<MaxValidator>(field.Validators, validator => validator.Value == 100);
		}

		[Fact]
		public virtual void Min() {
			var field = GetField<TextFieldComponent>(nameof(ITestValidatorModel.Min));
			AssertValidator<MinValidator>(field.Validators, validator => validator.Value == 10);
		}

		[Fact]
		public void Range() {
			var field = GetField<TextFieldComponent>(nameof(ITestValidatorModel.Range));
			AssertValidator<RangeValidator>(field.Validators, validator => (int) validator.Max == 100 && (int) validator.Min == 10);
		}

		[Fact]
		public void Email() {
			var field = GetField<TextFieldComponent>(nameof(ITestValidatorModel.Email));
			AssertValidator<EmailValidator>(field.Validators);
		}
	}
}