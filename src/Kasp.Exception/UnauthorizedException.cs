using System.Net;

namespace Kasp.Exception {
	public class UnauthorizedException : HttpExceptionBase {
		public override HttpStatusCode StatusCode { get; } = HttpStatusCode.Unauthorized;

		public UnauthorizedException() {
		}

		public UnauthorizedException(string message) : base(message) {
		}

		public UnauthorizedException(string message, System.Exception innerException) : base(message, innerException) {
		}
	}
	
}