using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.HttpException.Mappers {
	public class ProblemDetailMapper : IExceptionMapper {
		protected virtual string MapInstance(HttpResponse response) {
			return response.HttpContext.Request?.Path.HasValue == true ? response.HttpContext.Request.Path : null;
		}

		protected virtual int MapStatus(HttpResponse response) {
			return response.StatusCode;
		}

		protected virtual string MapTitle(HttpResponse response) {
			return response.StatusCode.ToString();
		}

		public IActionResult Map(System.Exception exception, HttpContext httpContext) {
			exception.
			var problemDetails = new ProblemDetails {
				Status = MapStatus(response),
				Type = MapType(response),
				Title = MapTitle(response),
				Detail = MapDetail(response),
				Instance = MapInstance(response)
			};
		}

		public IActionResult Map(HttpExceptionBase exception, HttpContext httpContext) {
			throw new System.NotImplementedException();
		}
	}
}