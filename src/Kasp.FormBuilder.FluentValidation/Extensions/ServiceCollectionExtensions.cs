using System;
using Kasp.FormBuilder.FluentValidation.Parsers;
using Kasp.FormBuilder.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.FormBuilder.FluentValidation.Extensions {
	public static class ServiceCollectionExtensions {
		public static IServiceCollection AddFluentValidation(this FormBuilderOptions formBuilderOptions) {
			formBuilderOptions.ServiceCollection.AddScoped<IValidatorResolver, FluentValidationValidatorResolver>();

			AddValidatorParsers(formBuilderOptions.ValidatorCollection);

			return formBuilderOptions.ServiceCollection;
		}

		private static void AddValidatorParsers(ComponentValidatorCollection validatorCollection) {
			validatorCollection.Add(new NotNullValidatorParser());
			validatorCollection.Add(new MaximumLengthValidatorParser());
			validatorCollection.Add(new LengthValidatorParser());
			validatorCollection.Add(new EmailValidatorParser());
		}
	}
}