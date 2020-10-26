using System;

namespace Kasp.Data.Models.Helpers {
	public interface ISoftDelete {
		DateTimeOffset? SoftDelete { set; get; }
	}
}