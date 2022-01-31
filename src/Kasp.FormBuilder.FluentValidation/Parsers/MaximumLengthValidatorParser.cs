using FluentValidation.Validators;
using Kasp.FormBuilder.Validators;

namespace Kasp.FormBuilder.FluentValidation.Parsers; 

public class MaximumLengthValidatorParser : BaseValidatorParser<MaximumLengthValidator, MaxLengthValidator> {
	public override MaxLengthValidator Parse(MaximumLengthValidator attribute) {
		return new MaxLengthValidator {Length = attribute.Max};
	}
}