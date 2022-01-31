using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.HttpException.Internal; 

public class HttpExceptionOptions {
	public Func<HttpContext, bool> IncludeExceptionDetails { get; set; }

	public Func<Exception, bool> ShouldLogException { get; set; }

	public bool UseHelpLinkAsProblemDetailsType { get; set; }
	public Uri DefaultHelpLink { get; set; }

	public Func<HttpContext, bool> IsExceptionResponse { get; set; }
}