using System;

namespace Kasp.Data.EF.Models.Helpers {
	public interface ISoftDelete {
		DateTime? SoftDelete { set; get; }
	}
}