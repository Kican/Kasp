namespace Kasp.FormBuilder.Validators {
	public class PatternValidator : BaseValidator {
		public override string Name => "pattern";
		public string Pattern { get; set; }
	}
}