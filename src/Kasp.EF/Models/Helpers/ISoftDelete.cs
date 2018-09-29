using System;

namespace Kasp.EF.Models.Helpers {
	public interface ISoftDelete {
		DateTime? SoftDelete { set; get; }
	}
}