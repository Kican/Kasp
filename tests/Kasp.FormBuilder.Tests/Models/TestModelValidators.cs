using System.ComponentModel.DataAnnotations;

namespace Kasp.FormBuilder.Tests.Models {
	public class TestModelValidators {
		[Required]
		public string Required { get; set; }

		[MaxLength(200)]
		public string MaxLength { get; set; }

		[MinLength(10)]
		public string MinLength { get; set; }
	}
}