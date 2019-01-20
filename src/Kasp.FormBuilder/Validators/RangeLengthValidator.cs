using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Validators {
    public class RangeLengthValidator : IValidator {
        public string Name => "rangelength";
        public int Min { get; set; }
        public int Max { get; set; }
    }
}