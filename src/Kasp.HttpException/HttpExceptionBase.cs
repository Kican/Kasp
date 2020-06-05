using System.Net;

namespace Kasp.HttpException {
	public abstract class HttpExceptionBase : System.Exception {
		public abstract HttpStatusCode StatusCode { get; }

		public object ErrorData { get; }

		public HttpExceptionBase() : base() {
		}

		public HttpExceptionBase(object errorData) : base() {
			ErrorData = errorData;
		}


		public HttpExceptionBase(string message) : base(message) {
		}

		public HttpExceptionBase(string message, object errorData) : base(message) {
			ErrorData = errorData;
		}


		public HttpExceptionBase(string message, System.Exception innerException) : base(message, innerException) {
		}

		public HttpExceptionBase(string message, object errorData, System.Exception innerException) : base(message, innerException) {
			ErrorData = errorData;
		}
	}
}