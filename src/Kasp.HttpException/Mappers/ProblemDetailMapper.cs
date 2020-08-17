using System;
using Kasp.Core.Extensions;
using Kasp.HttpException.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Kasp.HttpException.Mappers {
	public class ProblemDetailMapper : IExceptionMapper {
		private readonly IOptions<HttpExceptionOptions> _options;

		public ProblemDetailMapper(IOptions<HttpExceptionOptions> options) {
			_options = options;
		}

		public IActionResult Map(Exception exception, HttpContext httpContext) {
			var problemDetails = new ProblemDetails {
				Status = MapStatus(httpContext.Response),
				Type = MapType(exception, httpContext),
				Title = MapTitle(exception, httpContext),
				Detail = MapDetail(exception, httpContext),
				Instance = MapInstance(httpContext.Response)
			};

			if (_options.Value.IncludeExceptionDetails(httpContext))
				problemDetails.Extensions.Add("exception-details", new SerializableException(exception));
			
			return new ProblemDetailsResult(problemDetails);
		}

		protected virtual string MapDetail(Exception exception, HttpContext context) {
			return exception.Message;
		}


		protected virtual string MapInstance(HttpResponse response) {
			return response.HttpContext.Request?.Path.HasValue == true ? response.HttpContext.Request.Path : null;
		}

		protected virtual int MapStatus(HttpResponse response) {
			return response.StatusCode;
		}

		protected virtual string MapTitle(Exception exception, HttpContext context) {
			var name = exception.GetType().Name;

			if (name.Contains("`"))
				name = name.Substring(0, name.IndexOf('`'));

			if (name.EndsWith("Exception", StringComparison.InvariantCultureIgnoreCase))
				name = name.Substring(0, name.Length - "Exception".Length);

			return name;
		}

		protected virtual string MapType(Exception exception, HttpContext context) {
			Uri uri = null;
			if (_options.Value.UseHelpLinkAsProblemDetailsType) {
				if (!string.IsNullOrWhiteSpace(exception.HelpLink)) {
					try {
						uri = new Uri(exception.HelpLink);
					} catch {
					}
				}

				uri ??= _options.Value.DefaultHelpLink;
			}

			uri ??= new Uri($"error:{MapTitle(exception, context).ToSlug()}");

			return uri.ToString();
		}
		
	}
}