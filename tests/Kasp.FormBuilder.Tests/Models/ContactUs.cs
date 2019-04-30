using System;
using System.ComponentModel.DataAnnotations;

namespace Kasp.FormBuilder.Tests.Models {
	public class ContactUs {
		[Required]
		[EmailAddress, StringLength(60, MinimumLength = 10)]
		[Display(Name = "email address")]
		public string Email { get; set; }

		[Required]
		[Display(Name = "your name")]
		public string Name { get; set; }

		public string PhoneNumber { get; set; }

		[Required]
		[MaxLength(500)]
		public string Content { get; set; }

		public DateTime AddTime { get; set; }
	}
}