using Kasp.Identity.Core.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.Identity.Core.Controllers {
	[Authorize]
	public abstract class AuthController : Controller {
		private int _userId;

		public int UserId {
			get {
				if (_userId == 0)
					_userId = User.GetUserId();
				return _userId;
			}
		}
	}
}