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

			var propRule = validatorService.First(x => ((PropertyRule) x).PropertyName == propertyInfo.Name);
			var validators = new List<IValidator>();

			foreach (var fluentValidator in propRule.Validators) {
				var validator = FormBuilderOptions.ValidatorCollection.Convert(fluentValidator);
				if (validator != null)
					validators.Add(validator);
			}

			return validators.ToArray();
		}
	}
}