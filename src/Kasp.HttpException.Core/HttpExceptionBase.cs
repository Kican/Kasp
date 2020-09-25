using System.Net;

namespace Kasp.HttpException.Core {
	public abstract class HttpExceptionBase : System.Exception {
		public abstract HttpStatusCode StatusCode { get; }

		public object ErrorData { get; set; }

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