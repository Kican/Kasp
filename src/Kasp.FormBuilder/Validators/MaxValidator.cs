using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Validators {
    public class MaxValidator : IValidator {
        public string Name => "max";
        public int Value { get; set; }
    }
}