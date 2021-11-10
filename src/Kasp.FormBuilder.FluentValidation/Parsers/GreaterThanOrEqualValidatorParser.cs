using FluentValidation.Validators;
using Kasp.FormBuilder.Validators;

namespace Kasp.FormBuilder.FluentValidation.Parsers; 

public class GreaterThanOrEqualValidatorParser : BaseValidatorParser<GreaterThanOrEqualValidator, MinValidator> {
	public override MinValidator Parse(GreaterThanOrEqualValidator attribute) {
		return new MinValidator {Value = (int) attribute.ValueToCompare};
	}
}