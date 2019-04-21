using FluentValidation.Validators;
using Kasp.FormBuilder.Validators;

namespace Kasp.FormBuilder.FluentValidation.Parsers {
	public class MinimumLengthValidatorParser : BaseValidatorParser<MinimumLengthValidator, MinLengthValidator> {
		public override MinLengthValidator Parse(MinimumLengthValidator attribute) {
			return new MinLengthValidator {Length = attribute.Min};
		}
	}
}