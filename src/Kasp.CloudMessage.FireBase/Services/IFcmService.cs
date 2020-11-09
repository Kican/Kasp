using Kasp.CloudMessage.Services;

namespace Kasp.CloudMessage.FireBase.Services {
	public interface IFcmService : ICloudMessageService {
		// Task<FcmMessageResponse> SendAsync(Message message, CancellationToken cancellationToken = default);
		// Task<Result<bool>> SendToUserAsync(int userId, Message message, CancellationToken cancellationToken = default);
		// Task<Result<bool>> SendToAllAsync(Message message, CancellationToken cancellationToken = default);
	}
}