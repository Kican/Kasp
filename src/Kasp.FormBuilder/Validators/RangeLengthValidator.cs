namespace Kasp.FormBuilder.Validators; 

public class RangeLengthValidator : BaseValidator {
	public override string Name => "rangelength";
	public int Min { get; set; }
	public int Max { get; set; }
}