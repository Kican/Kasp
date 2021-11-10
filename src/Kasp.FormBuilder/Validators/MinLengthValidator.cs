namespace Kasp.FormBuilder.Validators; 

public class MinLengthValidator : BaseValidator {
	public override string Name => "minlength";
	public int Length { get; set; }
}