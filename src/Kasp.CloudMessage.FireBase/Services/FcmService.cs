using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FirebaseAdmin.Messaging;
using Kasp.CloudMessage.FireBase.Data;
using Kasp.CloudMessage.Models;

namespace Kasp.CloudMessage.FireBase.Services {
	public class FcmService : IFcmService {
		public FcmService(IFcmUserTokenRepository fcmUserTokenRepository) {
			FcmUserTokenRepository = fcmUserTokenRepository;
		}

		private IFcmUserTokenRepository FcmUserTokenRepository { get; }


		public async Task SendAsync(Message message, CancellationToken cancellationToken = default) {
			await FirebaseMessaging.DefaultInstance.SendAsync(message, cancellationToken);
		}

		public async Task SendToUserAsync(int userId, Message message, CancellationToken cancellationToken = default) {
			message.Token = await FcmUserTokenRepository.GetUserTokenAsync(userId, cancellationToken);
			await SendAsync(message, cancellationToken);
		}

		public async Task SendToAllAsync(Message message, CancellationToken cancellationToken = default) {
			message.Topic = "all";
			await SendAsync(message, cancellationToken);
		}

		public async Task SendToUserAsync(int userId, string title, string body, CancellationToken cancellationToken = default) {
			var fcmMessage = FromTitleBody(title, body);
			await SendToUserAsync(userId, fcmMessage, cancellationToken);
		}

		public async Task SendToUserAsync(int userId, Dictionary<string, string> data, CancellationToken cancellationToken = default) {
			var fcmMessage = new Message {Data = data};
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
			var fcmMessage = new Message() {Data = data};
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

		private Message FromTitleBody(string title, string body) {
			return new Message {Notification = new Notification {Title = title, Body = body}};
		}
	}
}