namespace Kasp.FormBuilder.Tests.Models {
	public interface ITestValidatorModel {
		string Required { get; set; }


		string MaxLength { get; set; } // max = 100
		string MinLength { get; set; } // min = 10
		string RangeLength { get; set; } // min = 10 , max = 100


		int Max { get; set; } // value = 100
		int Min { get; set; } // value = 10
		int Range { get; set; } // min = 10 , max = 100

		string Email { get; set; }

		string Url { get; set; }
	}
}