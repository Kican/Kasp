namespace Kasp.FormBuilder.Validators {
	public class MaxLengthValidator : BaseValidator {
		public override string Name => "maxlength";
		public int Length { get; set; }
	}
}