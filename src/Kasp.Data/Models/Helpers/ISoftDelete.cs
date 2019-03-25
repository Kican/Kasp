using System;

namespace Kasp.Data.Models.Helpers {
	public interface ISoftDelete {
		DateTime? SoftDelete { set; get; }
	}
}