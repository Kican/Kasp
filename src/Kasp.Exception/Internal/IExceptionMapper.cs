using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.Exception.Internal {
	public interface IExceptionMapper<TException> where TException : System.Exception {
		IActionResult Map(TException exception, HttpContext httpContext);
	}
}