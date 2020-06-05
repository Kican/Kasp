using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.HttpException.Internal {
	public interface IExceptionMapper<TException> where TException : System.Exception {
		IActionResult Map(TException exception, HttpContext httpContext);
	}
}