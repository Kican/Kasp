using System.ComponentModel.DataAnnotations;

namespace Kasp.FormBuilder.Validators.MvcAttributeParsers;

public class EmailAddressAttributeParser : BaseValidatorParser<EmailAddressAttribute, EmailValidator> {
	public override EmailValidator Parse(EmailAddressAttribute attribute) {
		return new EmailValidator();
	}
}
