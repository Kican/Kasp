using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Validators {
    public class MaxLengthValidator : IValidator {
        public string Name => "maxlength";
        public int Length { get; set; }
    }
}