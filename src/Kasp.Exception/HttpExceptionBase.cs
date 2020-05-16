using System.Net;

namespace Kasp.Exception {
	public abstract class HttpExceptionBase : System.Exception {
		public abstract HttpStatusCode StatusCode { get; }

		protected HttpExceptionBase() : base() {
		}

		protected HttpExceptionBase(string message) : base(message) {
		}

		protected HttpExceptionBase(string message, System.Exception innerException) : base(message, innerException) {
		}
	}

	public abstract class HttpExceptionBase<T> : HttpExceptionBase where T : class {
		public T ErrorData { get; }

		protected HttpExceptionBase(T errorData) : base() {
			ErrorData = errorData;
		}

		protected HttpExceptionBase(string message, T errorData) : base(message) {
			ErrorData = errorData;
		}

		protected HttpExceptionBase(string message, T errorData, System.Exception innerException) : base(message, innerException) {
			ErrorData = errorData;
		}
	}
}