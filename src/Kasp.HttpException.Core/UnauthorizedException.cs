using System.Net;

namespace Kasp.HttpException.Core; 

public class UnauthorizedException : HttpExceptionBase {
	public override HttpStatusCode StatusCode { get; } = HttpStatusCode.Unauthorized;

	public UnauthorizedException() {
	}

	public UnauthorizedException(string message) : base(message) {
	}

	public UnauthorizedException(string message, System.Exception innerException) : base(message, innerException) {
	}
}