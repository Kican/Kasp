using System.ComponentModel.DataAnnotations;

namespace Kasp.FormBuilder.Validators.MvcAttributeParsers {
	public class MinLengthAttributeParser : BaseValidatorParser<MinLengthAttribute, MinLengthValidator> {
		public override MinLengthValidator Parse(MinLengthAttribute attribute) {
			return new MinLengthValidator() {Length = attribute.Length};
		}
	}
}