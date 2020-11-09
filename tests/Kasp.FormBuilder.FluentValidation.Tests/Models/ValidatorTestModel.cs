using Kasp.FormBuilder.Tests.Models;

namespace Kasp.FormBuilder.FluentValidation.Tests.Models {
	public class ValidatorTestModel : ITestValidatorModel {
		public string Required { get; set; }
		public string MaxLength { get; set; }
		public string MinLength { get; set; }
		public string RangeLength { get; set; }
		public int Max { get; set; }
		public int Min { get; set; }
		public int Range { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Url { get; set; }
	}
}