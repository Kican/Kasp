using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Validators {
    public class PatternValidator : IValidator {
        public string Name => "pattern";
        public string Pattern { get; set; }
    }
}