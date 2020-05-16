using System.Net;

namespace Kasp.Exception {
	public class ForbiddenException : HttpExceptionBase {
		public override HttpStatusCode StatusCode { get; } = HttpStatusCode.Forbidden;

		public ForbiddenException() {
		}

		public ForbiddenException(string message) : base(message) {
		}

		public ForbiddenException(string message, System.Exception innerException) : base(message, innerException) {
		}
	}

	public class ForbiddenException<T> : HttpExceptionBase<T> where T : class {
		public override HttpStatusCode StatusCode { get; } = HttpStatusCode.Forbidden;

		public ForbiddenException(T errorData) : base(errorData) {
		}

		public ForbiddenException(string message, T errorData) : base(message, errorData) {
		}

		public ForbiddenException(string message, T errorData, System.Exception innerException) : base(message, errorData, innerException) {
		}
	}
}