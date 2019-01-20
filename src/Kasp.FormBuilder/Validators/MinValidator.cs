using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Validators {
    public class MinValidator : IValidator {
        public string Name => "min";
        public int Value { get; set; }
    }
}