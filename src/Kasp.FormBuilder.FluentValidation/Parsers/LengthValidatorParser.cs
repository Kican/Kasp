using FluentValidation.Validators;
using Kasp.FormBuilder.Validators;

namespace Kasp.FormBuilder.FluentValidation.Parsers; 

public class LengthValidatorParser : BaseValidatorParser<LengthValidator, RangeLengthValidator> {
	public override RangeLengthValidator Parse(LengthValidator attribute) {
		return new RangeLengthValidator {Max = attribute.Max, Min = attribute.Min};
	}
}