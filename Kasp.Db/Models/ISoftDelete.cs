using System;

namespace Kasp.Db.Models {
	public interface ISoftDelete {
		DateTime? SoftDelete { set; get; }
	}
}