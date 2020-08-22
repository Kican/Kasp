using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.HttpException.Internal {
	public interface IExceptionMapper {
		IActionResult Map(Exception exception, HttpContext httpContext);
	}
}