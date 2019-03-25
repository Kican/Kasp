using System;

namespace Kasp.Data.EF.Models.Helpers {
	public interface IUpdateTime {
		DateTime? UpdateTime { set; get; }
	}
}