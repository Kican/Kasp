using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kasp.CloudMessage.Models;
using Kasp.Core.Models;

namespace Kasp.CloudMessage.Services {
	public interface ICloudMessageService {
		Task<Result<bool>> SendToUserAsync(int userId, string title, string body, CancellationToken cancellationToken = default);
		Task<Result<bool>> SendToUserAsync(int userId, Dictionary<string, string> data, CancellationToken cancellationToken = default);
		Task<Result<bool>> SendToUserAsync(int userId, IMessage holder, CancellationToken cancellationToken = default);
		Task<Result<bool>> SendToUserAsync(int userId, string title, string body, Dictionary<string, string> data, CancellationToken cancellationToken = default);


		Task<Result<bool>> SendToAllAsync(string title, string body, CancellationToken cancellationToken = default);
		Task<Result<bool>> SendToAllAsync(Dictionary<string, string> data, CancellationToken cancellationToken = default);
		Task<Result<bool>> SendToAllAsync(IMessage holder, CancellationToken cancellationToken = default);
		Task<Result<bool>> SendToAllAsync(string title, string body, Dictionary<string, string> data, CancellationToken cancellationToken = default);

//		Task<bool> SendAsync(int userId, Message content);
//		Task<bool> SendAsync(Message content);
	}
}