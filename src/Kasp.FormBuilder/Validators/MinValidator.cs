namespace Kasp.FormBuilder.Validators; 

public class MinValidator : BaseValidator {
	public override string Name => "min";
	public int Value { get; set; }
}