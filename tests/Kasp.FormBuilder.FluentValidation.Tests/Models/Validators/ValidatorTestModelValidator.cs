using FluentValidation;

namespace Kasp.FormBuilder.FluentValidation.Tests.Models.Validators {
	public class ValidatorTestModelValidator : AbstractValidator<ValidatorTestModel> {
		public ValidatorTestModelValidator() {
			RuleFor(x => x.Required).NotNull();

			RuleFor(x => x.MinLength).MinimumLength(10);
			RuleFor(x => x.MaxLength).MaximumLength(100);
			RuleFor(x => x.RangeLength).Length(10,100);
			
			RuleFor(x => x.Min).GreaterThanOrEqualTo(10);
			RuleFor(x => x.Max).LessThanOrEqualTo(100);
			RuleFor(x => x.Range).InclusiveBetween(10, 100);

			RuleFor(x => x.Email).EmailAddress();
		}
	}
}