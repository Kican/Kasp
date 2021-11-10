using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder; 

public class MvcValidatorResolver : IValidatorResolver {
	public MvcValidatorResolver(FormBuilderOptions formBuilderOptions) {
		FormBuilderOptions = formBuilderOptions;
	}

	private FormBuilderOptions FormBuilderOptions { get; }

	public IValidator[] GetValidators(PropertyInfo propertyInfo) {
		var attributeValidators = propertyInfo.GetCustomAttributes<ValidationAttribute>();

		var validators = new List<IValidator>();
		foreach (var validationAttribute in attributeValidators) {
			var validator = FormBuilderOptions.ValidatorCollection.Convert(validationAttribute);
			if (validator != null)
				validators.Add(validator);
		}

		return validators.ToArray();
	}
}