using System;

namespace Kasp.Data.Models.Helpers {
	public interface IPublishTime {
		DateTimeOffset PublishTime { set; get; }
	}
}