using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FcmSharp;
using FcmSharp.Requests;
using FcmSharp.Responses;
using Kasp.CloudMessage.FireBase.Data;
using Kasp.CloudMessage.Models;
using Kasp.Core.Models;

namespace Kasp.CloudMessage.FireBase.Services {
	public class FcmService : IFcmService {
		public FcmService(IFcmClient fcmClient, IFcmUserTokenRepository fcmUserTokenRepository) {
			FcmClient = fcmClient;
			FcmUserTokenRepository = fcmUserTokenRepository;
		}

		private IFcmClient FcmClient { get; }
		private IFcmUserTokenRepository FcmUserTokenRepository { get; }


		public async Task<FcmMessageResponse> SendAsync(FcmMessage message, CancellationToken cancellationToken = default) {
			return await FcmClient.SendAsync(message, cancellationToken);
		}

		public async Task<Result<bool>> SendToUserAsync(int userId, FcmMessage message, CancellationToken cancellationToken = default) {
			message.Message.Token = await FcmUserTokenRepository.GetUserTokenAsync(userId, cancellationToken);
			await SendAsync(message, cancellationToken);
			return new Result<bool>(true);
		}

		public async Task<Result<bool>> SendToAllAsync(FcmMessage message, CancellationToken cancellationToken = default) {
			message.Message.Topic = "all";
			await SendAsync(message, cancellationToken);
			return new Result<bool>(true);
		}

		public async Task<Result<bool>> SendToUserAsync(int userId, string title, string body, CancellationToken cancellationToken = default) {
			var fcmMessage = FromTitleBody(title, body);
			await SendToUserAsync(userId, fcmMessage, cancellationToken);
			return new Result<bool>(true);
		}

		public async Task<Result<bool>> SendToUserAsync(int userId, Dictionary<string, string> data, CancellationToken cancellationToken = default) {
			var fcmMessage = new FcmMessage {
				Message = new Message {
					Data = data
				}
			};
			await SendToUserAsync(userId, fcmMessage, cancellationToken);
			return new Result<bool>(true);
		}

		public Task<Result<bool>> SendToUserAsync(int userId, IMessage holder, CancellationToken cancellationToken = default) {
			throw new System.NotImplementedException();
		}

		public async Task<Result<bool>> SendToUserAsync(int userId, string title, string body, Dictionary<string, string> data, CancellationToken cancellationToken = default) {
			var fcmMessage = FromTitleBody(title, body);
			fcmMessage.Message.Data = data;
			await SendToUserAsync(userId, fcmMessage, cancellationToken);
			return new Result<bool>(true);
		}

		public async Task<Result<bool>> SendToAllAsync(string title, string body, CancellationToken cancellationToken = default) {
			var fcmMessage = FromTitleBody(title, body);
			await SendToAllAsync(fcmMessage, cancellationToken);
			return new Result<bool>(true);
		}

		public async Task<Result<bool>> SendToAllAsync(Dictionary<string, string> data, CancellationToken cancellationToken = default) {
			var fcmMessage = new FcmMessage {
				Message = new Message {
					Data = data
				}
			};
			await SendToAllAsync(fcmMessage, cancellationToken);
			return new Result<bool>(true);
		}

		public Task<Result<bool>> SendToAllAsync(IMessage holder, CancellationToken cancellationToken = default) {
			throw new System.NotImplementedException();
		}

		public async Task<Result<bool>> SendToAllAsync(string title, string body, Dictionary<string, string> data, CancellationToken cancellationToken = default) {
			var fcmMessage = FromTitleBody(title, body);
			fcmMessage.Message.Data = data;
			await SendToAllAsync(fcmMessage, cancellationToken);
			return new Result<bool>(true);
		}

		private FcmMessage FromTitleBody(string title, string body) {
			return new FcmMessage {
				Message = new Message {
					Notification = new Notification {
						Title = title, Body = body
					}
				}
			};
		}
	}
}