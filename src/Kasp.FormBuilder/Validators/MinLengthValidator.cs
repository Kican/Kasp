using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Validators {
    public class MinLengthValidator : IValidator {
        public string Name => "minlength";
        public int Length { get; set; }
    }
}