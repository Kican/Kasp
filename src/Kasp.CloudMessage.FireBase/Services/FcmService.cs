using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kasp.CloudMessage.FireBase.Data;
using Kasp.CloudMessage.FireBase.Models;
using Kasp.CloudMessage.Models;

namespace Kasp.CloudMessage.FireBase.Services {
	public class FcmService : IFcmService {
		public FcmService(IFcmUserTokenRepository fcmUserTokenRepository, FcmApiHttpClient httpClient) {
			_fcmUserTokenRepository = fcmUserTokenRepository;
			_httpClient = httpClient;
		}

		private readonly IFcmUserTokenRepository _fcmUserTokenRepository;
		private readonly FcmApiHttpClient _httpClient;

		public async Task SendAsync(FcmMessage message, CancellationToken cancellationToken = default) {
			await _httpClient.SendAsync(message, cancellationToken);
		}

		public async Task SendToUserAsync(int userId, FcmMessage message, CancellationToken cancellationToken = default) {
			message.To = await _fcmUserTokenRepository.GetUserTokenAsync(userId, cancellationToken);
			await SendAsync(message, cancellationToken);
		}

		public async Task SendToAllAsync(FcmMessage message, CancellationToken cancellationToken = default) {
			message.To = "all";
			await SendAsync(message, cancellationToken);
		}

		public async Task SendToUserAsync(int userId, string title, string body, CancellationToken cancellationToken = default) {
			var fcmMessage = FromTitleBody(title, body);
			await SendToUserAsync(userId, fcmMessage, cancellationToken);
		}

		public async Task SendToUserAsync(int userId, Dictionary<string, string> data, CancellationToken cancellationToken = default) {
			var fcmMessage = new FcmMessage {Data = data};
			await SendToUserAsync(userId, fcmMessage, cancellationToken);
		}

		public Task SendToUserAsync(int userId, IMessage holder, CancellationToken cancellationToken = default) {
			throw new System.NotImplementedException();
		}

		public async Task SendToUserAsync(int userId, string title, string body, Dictionary<string, string> data, CancellationToken cancellationToken = default) {
			var fcmMessage = FromTitleBody(title, body);
			fcmMessage.Data = data;
			await SendToUserAsync(userId, fcmMessage, cancellationToken);
		}

		public async Task SendToAllAsync(string title, string body, CancellationToken cancellationToken = default) {
			var fcmMessage = FromTitleBody(title, body);
			await SendToAllAsync(fcmMessage, cancellationToken);
		}

		public async Task SendToAllAsync(Dictionary<string, string> data, CancellationToken cancellationToken = default) {
			var fcmMessage = new FcmMessage() {Data = data};
			await SendToAllAsync(fcmMessage, cancellationToken);
		}

		public Task SendToAllAsync(IMessage holder, CancellationToken cancellationToken = default) {
			throw new System.NotImplementedException();
		}

		public async Task SendToAllAsync(string title, string body, Dictionary<string, string> data, CancellationToken cancellationToken = default) {
			var fcmMessage = FromTitleBody(title, body);
			fcmMessage.Data = data;
			await SendToAllAsync(fcmMessage, cancellationToken);
		}

		private FcmMessage FromTitleBody(string title, string body) {
			return new FcmMessage {Notification = new FcmNotification() {Title = title, Body = body}};
		}
	}
}
