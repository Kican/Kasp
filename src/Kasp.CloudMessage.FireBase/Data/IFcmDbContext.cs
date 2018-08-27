using Kasp.CloudMessage.FireBase.Models.UserTokenModels;
using Microsoft.EntityFrameworkCore;

namespace Kasp.CloudMessage.FireBase.Data {
	public interface IFcmDbContext {
		DbSet<FcmUserToken> FcmUserTokens { get; set; }
	}
}