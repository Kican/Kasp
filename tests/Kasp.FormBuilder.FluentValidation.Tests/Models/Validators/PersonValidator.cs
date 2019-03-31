using FluentValidation;

namespace Kasp.FormBuilder.FluentValidation.Tests.Models.Validators {
	public class PersonValidator : AbstractValidator<Person> {
		public PersonValidator() {
			RuleFor(x => x.Name).NotNull().Length(10, 100);
			RuleFor(x => x.Family).NotNull().MaximumLength(100);
		}
	}
}