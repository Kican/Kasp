using System.Threading.Tasks;
using Kasp.CloudMessage.FireBase.Settings;
using Kasp.CloudMessage.Models;
using Kasp.CloudMessage.Services;

namespace Kasp.CloudMessage.FireBase.Services {
	public class FcmClient : ICloudMessageClient {
		public FcmClient(FcmClientSettings clientSettings) {
			ClientSettings = clientSettings;
		}

		private FcmClientSettings ClientSettings { get; }

		public Task<bool> SendToUserAsync(int userId, string title) {
			throw new System.NotImplementedException();
		}

		public Task<bool> SendToUserAsync(int userId, string title, string body) {
			throw new System.NotImplementedException();
		}

		public Task<bool> SendToUserAsync(int userId, object data) {
			throw new System.NotImplementedException();
		}

		public Task<bool> SendToUserAsync(int userId, IMessage holder) {
			throw new System.NotImplementedException();
		}

		public Task<bool> SendToUserAsync(int userId, string title, object data) {
			throw new System.NotImplementedException();
		}

		public Task<bool> SendToAllAsync(string title) {
			throw new System.NotImplementedException();
		}

		public Task<bool> SendToAllAsync(string title, string body) {
			throw new System.NotImplementedException();
		}

		public Task<bool> SendToAllAsync(object data) {
			throw new System.NotImplementedException();
		}

		public Task<bool> SendToAllAsync(IMessage holder) {
			throw new System.NotImplementedException();
		}

		public Task<bool> SendToAllAsync(string title, object data) {
			throw new System.NotImplementedException();
		}
	}
}