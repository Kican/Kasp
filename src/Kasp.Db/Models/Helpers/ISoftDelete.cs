using System;

namespace Kasp.Db.Models.Helpers {
	public interface ISoftDelete {
		DateTime? SoftDelete { set; get; }
	}
}