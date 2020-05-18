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
}