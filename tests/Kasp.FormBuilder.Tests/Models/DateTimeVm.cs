using System;

namespace Kasp.FormBuilder.Tests.Models {
	public class DateTimeVm {
		public DateTime DateTime { get; set; }
		public DateTime? DateTimeNullable { get; set; }
		public DateTimeOffset DateTimeOffset { get; set; }
		public DateTimeOffset? DateTimeOffsetNullable { get; set; }
	}
}