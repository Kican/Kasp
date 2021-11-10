using System.ComponentModel.DataAnnotations;

namespace Kasp.FormBuilder.Validators.MvcAttributeParsers; 

public class RequiredAttributeParser : BaseValidatorParser<RequiredAttribute, RequiredValidator> {
	public override RequiredValidator Parse(RequiredAttribute attribute) {
		return new RequiredValidator();
	}
}