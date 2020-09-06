using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Kasp.FormBuilder.Components.Handlers;

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

		public int Number { get; set; }

		[Required,MaxLength(500)] 
		public string Content { get; set; }

		[Select("/api/users")]
		public int UserId { get; set; }

		public DateTime AddTime { get; set; }

		public Orientation Orientation { get; set; }
	}

	public enum Orientation {
		[Display(Name = "vert")]
		Vertical = 0,
		Horizontal = 1
	}
}