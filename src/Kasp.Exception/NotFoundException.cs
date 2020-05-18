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
}