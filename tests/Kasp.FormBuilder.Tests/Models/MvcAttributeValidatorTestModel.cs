using System.ComponentModel.DataAnnotations;

namespace Kasp.FormBuilder.Tests.Models {
	public class MvcAttributeValidatorTestModel : ITestValidatorModel {
		[Required]
		public string Required { get; set; }

		[MaxLength(100)]
		public string MaxLength { get; set; }

		[MinLength(10)]
		public string MinLength { get; set; }

		[StringLength(100, MinimumLength = 10)]
		public string RangeLength { get; set; }

		public int Max { get; set; }
		public int Min { get; set; }

		[Range(10, 100)]
		public int Range { get; set; }

		[EmailAddress]
		public string Email { get; set; }

		public string Url { get; set; }
	}
}