using Kasp.CloudMessage.Models;
using Kasp.CloudMessage.Models.TokenModels;
using Microsoft.EntityFrameworkCore;

namespace Kasp.CloudMessage.Data {
	public interface ICloudMessageDbContext {
		DbSet<UserCloudMessageToken> UserCloudMessageTokens { get; set; }
	}
}