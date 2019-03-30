namespace Kasp.FormBuilder.Validators {
    public class RangeValidator : BaseValidator {
        public override string Name => "range";
        public int Min { get; set; }
        public int Max { get; set; }
    }
}