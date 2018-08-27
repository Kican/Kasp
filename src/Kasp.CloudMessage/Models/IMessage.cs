using System.Collections.Generic;

namespace Kasp.CloudMessage.Models {
	public interface IMessage {
		string Key { get; set; }
		Dictionary<string, object> Data { get; set; }
	}
}