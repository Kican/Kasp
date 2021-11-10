namespace Kasp.FormBuilder.Models; 

public interface IValidator {
	string Name { get; }
	string Message { get; set; }
}