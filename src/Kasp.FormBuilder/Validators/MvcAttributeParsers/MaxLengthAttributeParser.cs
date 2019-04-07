using System.ComponentModel.DataAnnotations;

namespace Kasp.FormBuilder.Validators.MvcAttributeParsers {
	public class MaxLengthAttributeParser : BaseValidatorParser<MaxLengthAttribute, MaxLengthValidator> {
		public override MaxLengthValidator Parse(MaxLengthAttribute attribute) => new MaxLengthValidator {Length = attribute.Length, Message = attribute.ErrorMessage};
	}
}