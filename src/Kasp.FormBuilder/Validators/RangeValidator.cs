using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Validators {
    public class RangeValidator : IValidator {
        public string Name => "range";
        public int Min { get; set; }
        public int Max { get; set; }
    }
}