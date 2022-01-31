using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Validators;

public abstract class BaseValidator : IValidator {
	public abstract string Name { get; }
	public string Message { get; set; }
}
