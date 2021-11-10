using System.Security.Claims;

namespace Kasp.Identity.Core.Extensions;

public static class AuthExtensions {
	public static int GetUserId(this ClaimsPrincipal principal) {
		var userId = principal.FindFirst(ClaimTypes.NameIdentifier) ?? principal.FindFirst("sub");
		return int.Parse(userId.Value);
	}
}
