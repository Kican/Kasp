using System.Threading;
using System.Threading.Tasks;
using FcmSharp.Requests;
using FcmSharp.Responses;
using Kasp.CloudMessage.Services;
using Kasp.Core.Models;

namespace Kasp.CloudMessage.FireBase.Services {
	public interface IFcmService : ICloudMessageService {
		Task<FcmMessageResponse> SendAsync(FcmMessage message, CancellationToken cancellationToken = default);
		Task<Result<bool>> SendToUserAsync(int userId, FcmMessage message, CancellationToken cancellationToken = default);
		Task<Result<bool>> SendToAllAsync(FcmMessage message, CancellationToken cancellationToken = default);
	}
}