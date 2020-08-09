using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.Exception.Internal {
	public class HttpExceptionOptions {
		public Func<HttpContext, bool> IncludeExceptionDetails { get; set; }

		public Func<System.Exception, bool> ShouldLogException { get; set; }

		// public Func<HttpContext, bool> IsExceptionResponse { get; set; }
		// private ICollection<IExceptionMapper> ExceptionMappers { get; set; } = new Dictionary<Type, IExceptionMapper>();
		//
		// public void MapException<TException, TMapper>() where TException : System.Exception where TMapper : IExceptionMapper {
		// }
		//
		// internal IActionResult MapToAction(System.Exception exception, HttpContext context) {
		// 	if(ExceptionMappers.ContainsKey(exception.GetType()))
		// 	return ExceptionMapper.Map(exception, context)
		// }
	}
}