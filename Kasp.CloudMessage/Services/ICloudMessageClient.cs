using System.Threading.Tasks;
using Kasp.CloudMessage.Models;

namespace Kasp.CloudMessage.Services {
	public interface ICloudMessageClient {
		Task<bool> SendToUserAsync(int userId, string title);
		Task<bool> SendToUserAsync(int userId, string title, string body);
		Task<bool> SendToUserAsync(int userId, object data);
		Task<bool> SendToUserAsync(int userId, IMessage holder);
		Task<bool> SendToUserAsync(int userId, string title, object data);


		Task<bool> SendToAllAsync(string title);
		Task<bool> SendToAllAsync(string title, string body);
		Task<bool> SendToAllAsync(object data);
		Task<bool> SendToAllAsync(IMessage holder);
		Task<bool> SendToAllAsync(string title, object data);


//		Task<bool> SendAsync(int userId, Message content);
//		Task<bool> SendAsync(Message content);
	}
}