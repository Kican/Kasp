using System.Net;

namespace Kasp.HttpException.Core; 

public class HttpException : HttpExceptionBase {
	public override HttpStatusCode StatusCode { get; } = HttpStatusCode.InternalServerError;

	public HttpException() : base() {
	}

	public HttpException(object errorData) : base(errorData) {
	}

	public HttpException(string message, object errorData) : base(message, errorData) {
	}

	public HttpException(string message, object errorData, System.Exception innerException) : base(message, errorData, innerException) {
	}


	public HttpException(string message) : base(message) {
	}

	public HttpException(string message, System.Exception innerException) : base(message, innerException) {
	}

	public HttpException(HttpStatusCode statusCode) : base() => StatusCode = statusCode;
	public HttpException(HttpStatusCode statusCode, string message) : base(message) => StatusCode = statusCode;
	public HttpException(HttpStatusCode statusCode, string message, System.Exception innerException) : base(message, innerException) => StatusCode = statusCode;
}