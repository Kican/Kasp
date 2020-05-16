using System.Net;

namespace Kasp.Exception {
	public class NotFoundException : HttpExceptionBase {
		public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

		public NotFoundException() {
		}

		public NotFoundException(string message) : base(message) {
		}

		public NotFoundException(string message, System.Exception innerException) : base(message, innerException) {
		}
	}

	public class NotFoundException<T> : HttpExceptionBase<T> where T : class {
		public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

		public NotFoundException(T errorData) : base(errorData) {
		}

		public NotFoundException(string message, T errorData) : base(message, errorData) {
		}

		public NotFoundException(string message, T errorData, System.Exception innerException) : base(message, errorData, innerException) {
		}
	}
}