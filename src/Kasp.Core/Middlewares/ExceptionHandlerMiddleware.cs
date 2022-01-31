using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Kasp.Core.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Kasp.Core.Middlewares; 

public static class ExceptionHandlerMiddleware {
	public static KaspAppBuilder UseExceptionHandler(this KaspAppBuilder app) {
		app.ApplicationBuilder.UseExceptionHandler(builder => {
			builder.Run(async context => {
				context.Response.ContentType = "application/json";

				var error = new ErrorDetails();

				var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
					
				if (contextFeature.Error is KaspRuntimeException exception) {
					error.Status = (int) exception.StatusCode;
					error.Message = exception.Message;
				} else {
					error.Status = (int) HttpStatusCode.InternalServerError;
					error.Message = contextFeature.Error.Message;
				}

				context.Response.StatusCode = error.Status;

				await context.Response.WriteAsync(JsonSerializer.Serialize(error));
			});
		});

		return app;
	}
}

public class ErrorDetails {
	public string Message { get; set; }
	public int Status { get; set; }
	public DateTimeOffset Time { get; set; } = DateTimeOffset.Now;
	public Dictionary<string, string[]> Errors { get; set; }
}

public abstract class KaspRuntimeException : Exception {
	public abstract HttpStatusCode StatusCode { get; }

	public KaspRuntimeException(string message) : base(message) {
	}
}

public class EntityNotFoundException : KaspRuntimeException {
	public object Key { get; }
	public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

	public EntityNotFoundException(object key) : base($"Entity {key} not found ...") {
		Key = key;
	}
}

public class EntityAlreadyExistException : KaspRuntimeException {
	public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

	public EntityAlreadyExistException(object key) : base($"Entity {key} is exist ...") {
	}
}