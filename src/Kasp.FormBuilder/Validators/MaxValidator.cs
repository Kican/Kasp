namespace Kasp.FormBuilder.Validators; 

public class MaxValidator : BaseValidator {
	public override string Name => "max";
	public int Value { get; set; }
}