using System.Net;

namespace Kasp.HttpException.Core; 

public class ForbiddenException : HttpExceptionBase {
	public override HttpStatusCode StatusCode { get; } = HttpStatusCode.Forbidden;

	public ForbiddenException() {
	}

	public ForbiddenException(string message) : base(message) {
	}

	public ForbiddenException(string message, System.Exception innerException) : base(message, innerException) {
	}
}