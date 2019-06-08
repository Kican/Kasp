using System;
using Kasp.FormBuilder.FluentValidation.Parsers;
using Kasp.FormBuilder.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.FormBuilder.FluentValidation.Extensions {
	public static class ServiceCollectionExtensions {
		public static void AddFluentValidation(this FormBuilderOptions formBuilderOptions) {
			formBuilderOptions.ServiceCollection.AddScoped<IValidatorResolver, FluentValidationValidatorResolver>();

			AddValidatorParsers(formBuilderOptions.ValidatorCollection);
		}

		private static void AddValidatorParsers(ComponentValidatorCollection validatorCollection) {
			validatorCollection.Add(new NotNullValidatorParser());
			validatorCollection.Add(new MaximumLengthValidatorParser());
			validatorCollection.Add(new MinimumLengthValidatorParser());
			validatorCollection.Add(new LengthValidatorParser());
			validatorCollection.Add(new EmailValidatorParser());
			
			validatorCollection.Add(new LessThanOrEqualValidatorParser());
			validatorCollection.Add(new GreaterThanOrEqualValidatorParser());
			validatorCollection.Add(new InclusiveBetweenValidatorParser());
		}
	}
}