using System.Net;

namespace Kasp.Exception {
	public class HttpException : HttpExceptionBase {
		public override HttpStatusCode StatusCode { get; } = HttpStatusCode.InternalServerError;

		public HttpException() : base() {
		}

		public HttpException(string message) : base(message) {
		}

		public HttpException(string message, System.Exception innerException) : base(message, innerException) {
		}

		public HttpException(HttpStatusCode statusCode) : base() => StatusCode = statusCode;
		public HttpException(HttpStatusCode statusCode, string message) : base(message) => StatusCode = statusCode;
		public HttpException(HttpStatusCode statusCode, string message, System.Exception innerException) : base(message, innerException) => StatusCode = statusCode;
	}

	public class HttpException<T> : HttpExceptionBase<T> where T : class {
		public override HttpStatusCode StatusCode { get; } = HttpStatusCode.InternalServerError;

		public HttpException(T errorData) : base(errorData) {
		}

		public HttpException(string message, T errorData) : base(message, errorData) {
		}

		public HttpException(string message, T errorData, System.Exception innerException) : base(message, errorData, innerException) {
		}

		public HttpException(HttpStatusCode statusCode, T errorData) : base(errorData) => StatusCode = statusCode;

		public HttpException(HttpStatusCode statusCode, string message, T errorData) : base(message, errorData) => StatusCode = statusCode;

		public HttpException(HttpStatusCode statusCode, string message, T errorData, System.Exception innerException) : base(message, errorData, innerException) => StatusCode = statusCode;
	}
}