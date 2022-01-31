using FluentValidation.Validators;
using Kasp.FormBuilder.Validators;

namespace Kasp.FormBuilder.FluentValidation.Parsers; 

public class NotNullValidatorParser : BaseValidatorParser<NotNullValidator, RequiredValidator> {
	public override RequiredValidator Parse(NotNullValidator attribute) {
		return new RequiredValidator();
	}
}