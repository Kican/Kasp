using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentValidation;
using FluentValidation.Internal;
using IValidator = Kasp.FormBuilder.Models.IValidator;

namespace Kasp.FormBuilder.FluentValidation {
	public class FluentValidationValidatorResolver : IValidatorResolver {
		public FluentValidationValidatorResolver(IServiceProvider serviceProvider, FormBuilderOptions formBuilderOptions) {
			ServiceProvider = serviceProvider;
			FormBuilderOptions = formBuilderOptions;
		}

		private FormBuilderOptions FormBuilderOptions { get; }
		private IServiceProvider ServiceProvider { get; }

		public IValidator[] GetValidators(PropertyInfo propertyInfo) {
			var validatorType = typeof(IValidator<>).MakeGenericType(propertyInfo.DeclaringType);
			var validatorService = ServiceProvider.GetService(validatorType) as IEnumerable<IValidationRule>;

			if (validatorService == null)
				return new IValidator[] { };

			var propRule = validatorService.FirstOrDefault(x => ((PropertyRule) x).PropertyName == propertyInfo.Name);
			var validators = new List<IValidator>();

			if (propRule == null || !propRule.Validators.Any())
				return validators.ToArray();

			validators.AddRange(propRule.Validators.Select(fluentValidator =>
						FormBuilderOptions.ValidatorCollection.Convert(fluentValidator)).Where(validator => validator != null)
				);

			return validators.ToArray();
		}
	}
}
