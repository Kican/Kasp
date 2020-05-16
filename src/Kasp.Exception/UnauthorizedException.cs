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

	public class UnauthorizedException<T> : HttpExceptionBase<T> where T : class {
		public override HttpStatusCode StatusCode { get; } = HttpStatusCode.Unauthorized;

		public UnauthorizedException(T errorData) : base(errorData) {
		}

		public UnauthorizedException(string message, T errorData) : base(message, errorData) {
		}

		public UnauthorizedException(string message, T errorData, System.Exception innerException) : base(message, errorData, innerException) {
		}
	}
}