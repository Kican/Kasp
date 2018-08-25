using System.Threading.Tasks;
using Kasp.CloudMessage.Models;
using Kasp.Core.Models;

namespace Kasp.CloudMessage.Services {
	public interface ICloudMessageClient {
		Task<Result<bool>> SendToUserAsync(int userId, string title);
		Task<Result<bool>> SendToUserAsync(int userId, string title, string body);
		Task<Result<bool>> SendToUserAsync(int userId, object data);
		Task<Result<bool>> SendToUserAsync(int userId, IMessage holder);
		Task<Result<bool>> SendToUserAsync(int userId, string title, object data);


		Task<Result<bool>> SendToAllAsync(string title);
		Task<Result<bool>> SendToAllAsync(string title, string body);
		Task<Result<bool>> SendToAllAsync(object data);
		Task<Result<bool>> SendToAllAsync(IMessage holder);
		Task<Result<bool>> SendToAllAsync(string title, object data);

//		Task<bool> SendAsync(int userId, Message content);
//		Task<bool> SendAsync(Message content);
	}
}