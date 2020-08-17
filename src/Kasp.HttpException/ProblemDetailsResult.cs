using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Kasp.HttpException {
	public class ProblemDetailsResult : ObjectResult {
		public new ProblemDetails Value {
			get => (ProblemDetails) base.Value;
			set => base.Value = value;
		}
		
		public ProblemDetailsResult(ProblemDetails problemDetails) : base(problemDetails) {
			StatusCode = problemDetails.Status;
			DeclaredType = problemDetails.GetType();

			ContentTypes.Add(new MediaTypeHeaderValue("application/problem+json"));
			ContentTypes.Add(new MediaTypeHeaderValue("application/problem+xml"));
		}
	}
}