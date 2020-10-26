using System;

namespace Kasp.Data.Models.Helpers {
	public interface IUpdateTime {
		DateTimeOffset? UpdateTime { set; get; }
	}
}