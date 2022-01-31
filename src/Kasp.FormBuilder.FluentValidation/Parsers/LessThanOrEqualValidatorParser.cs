using FluentValidation.Validators;
using Kasp.FormBuilder.Validators;

namespace Kasp.FormBuilder.FluentValidation.Parsers; 

public class LessThanOrEqualValidatorParser : BaseValidatorParser<LessThanOrEqualValidator, MaxValidator> {
	public override MaxValidator Parse(LessThanOrEqualValidator attribute) {
		return new MaxValidator {Value = (int) attribute.ValueToCompare};
	}
}