using System;
using System.Collections.Generic;
using System.Linq;

namespace Kasp.Core.Models; 

public class Result {
	public Dictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();
	public Exception Exception { get; set; }

	public Result AddError(string key, string message) {
		if (Errors.ContainsKey(key))
			Errors[key].Add(message);
		else
			Errors.Add(key, new List<string> {message});

		return this;
	}

	public Result AddError(string key, string[] messages) {
		if (Errors.ContainsKey(key))
			Errors[key].AddRange(messages);
		else
			Errors.Add(key, messages.ToList());

		return this;
	}

	public bool IsSuccess => Errors.Count == 0;

	public static Result WithError(string key, string message) {
		var result = new Result();
		result.AddError(key, message);

		return result;
	}

	public static Result NoError() => new Result();
}

public class Result<T> : Result {
	public T Data { get; set; }

	public Result() {
	}

	public Result(T data) {
		Data = data;
	}
		
	public Result<T> AddError(string key, string[] messages) {
		if (Errors.ContainsKey(key))
			Errors[key].AddRange(messages);
		else
			Errors.Add(key, messages.ToList());

		return this;
	}


	public static Result<T> WithError(string key, string message) {
		var result = new Result<T>();
		result.AddError(key, message);

		return result;
	}
}