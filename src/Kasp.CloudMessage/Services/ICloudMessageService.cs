using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kasp.CloudMessage.Models;
using Kasp.Core.Models;

namespace Kasp.CloudMessage.Services {
	public interface ICloudMessageService {
		Task SendToUserAsync(int userId, string title, string body, CancellationToken cancellationToken = default);
		Task SendToUserAsync(int userId, Dictionary<string, string> data, CancellationToken cancellationToken = default);
		Task SendToUserAsync(int userId, IMessage holder, CancellationToken cancellationToken = default);
		Task SendToUserAsync(int userId, string title, string body, Dictionary<string, string> data, CancellationToken cancellationToken = default);


		Task SendToAllAsync(string title, string body, CancellationToken cancellationToken = default);
		Task SendToAllAsync(Dictionary<string, string> data, CancellationToken cancellationToken = default);
		Task SendToAllAsync(IMessage holder, CancellationToken cancellationToken = default);
		Task SendToAllAsync(string title, string body, Dictionary<string, string> data, CancellationToken cancellationToken = default);
	}
}