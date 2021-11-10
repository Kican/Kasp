using FluentValidation.Validators;
using Kasp.FormBuilder.Validators;

namespace Kasp.FormBuilder.FluentValidation.Parsers; 

public class InclusiveBetweenValidatorParser : BaseValidatorParser<InclusiveBetweenValidator, RangeValidator> {
	public override RangeValidator Parse(InclusiveBetweenValidator attribute) {
		return new RangeValidator {Max = attribute.To, Min = attribute.From};
	}
}