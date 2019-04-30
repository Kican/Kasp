using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kasp.FormBuilder.Tests.Models {
	public class DateTimeVm {
		[Display(Name = "date 1")]
		public DateTime DateTime { get; set; }

		[DisplayName("date 2")]
		public DateTime? DateTimeNullable { get; set; }

		public DateTimeOffset DateTimeOffset { get; set; }
		public DateTimeOffset? DateTimeOffsetNullable { get; set; }
	}
}