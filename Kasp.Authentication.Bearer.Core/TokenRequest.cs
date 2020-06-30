using System.Collections.Generic;
using System.Security.Claims;

namespace Kasp.Authentication.Bearer.Core {
	public class TokenRequest {
		public IEnumerable<Claim> Claims { get; set; }
		
		/// <summary>
		/// Token Lifer time per second (3600 = 5 min) 
		/// </summary>
		public int TokenLifeTime { get; set; }
	}
}