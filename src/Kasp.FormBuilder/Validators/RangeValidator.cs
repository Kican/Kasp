namespace Kasp.FormBuilder.Validators {
    public class RangeValidator : BaseValidator {
        public override string Name => "range";
        public object Min { get; set; }
        public object Max { get; set; }
    }
}