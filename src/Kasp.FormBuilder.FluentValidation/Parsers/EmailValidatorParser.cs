using FluentValidation.Validators;

namespace Kasp.FormBuilder.FluentValidation.Parsers {
	public class EmailValidatorParser : BaseValidatorParser<EmailValidator, Validators.EmailValidator> {
		public override Validators.EmailValidator Parse(EmailValidator attribute) {
			return new Validators.EmailValidator();
		}
	}
}