using System.ComponentModel.DataAnnotations;

namespace Kasp.FormBuilder.Validators.MvcAttributeParsers; 

public class RangeAttributeParser : BaseValidatorParser<RangeAttribute, RangeValidator> {
	public override RangeValidator Parse(RangeAttribute attribute) {
		return new RangeValidator() {Min = attribute.Minimum, Max = attribute.Maximum};
	}
}