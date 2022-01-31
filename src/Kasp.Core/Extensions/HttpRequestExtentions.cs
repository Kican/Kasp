using System;
using Microsoft.AspNetCore.Http;

namespace Kasp.Core.Extensions; 

public static class HttpRequestExtensions {
	public static bool IsAjaxRequest(this HttpRequest request) {
		if (request == null) throw new ArgumentNullException();

		return request.Headers["X-Requested-With"] == "XMLHttpRequest";
	}

	public static string GetRootUrl(this HttpRequest request) {
		return $"{request.Scheme}://{request.Host}/";
	}
}