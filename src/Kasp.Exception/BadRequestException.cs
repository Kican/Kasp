using System.Net;

namespace Kasp.Exception {
	public class BadRequestException : HttpExceptionBase {
		public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

		public BadRequestException() {
		}

		public BadRequestException(string message) : base(message) {
		}

		public BadRequestException(string message, System.Exception innerException) : base(message, innerException) {
		}
	}

	public class BadRequestException<T> : HttpExceptionBase<T> where T : class {
		public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

		public BadRequestException(T errorData) : base(errorData) {
		}

		public BadRequestException(string message, T errorData) : base(message, errorData) {
		}

		public BadRequestException(string message, T errorData, System.Exception innerException) : base(message, errorData, innerException) {
		}
	}
}