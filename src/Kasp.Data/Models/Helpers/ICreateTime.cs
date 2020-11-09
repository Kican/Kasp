using System;

namespace Kasp.Data.Models.Helpers {
	public interface ICreateTime {
		DateTimeOffset CreateTime { set; get; }
	}
}