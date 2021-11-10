using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Kasp.HttpException; 

[Serializable]
public class SerializableException : ISerializable {
	public string Type { get; set; }
	public SerializableException InnerException { get; set; }
	public string HelpLink { get; set; }
	public int HResult { get; set; }
	public string Message { get; set; }
	public string Source { get; set; }
	public string StackTrace { get; set; }
		
	public IDictionary<string, object> Data { get; set; } = new Dictionary<string, object>();

	public SerializableException() {
	}

	public SerializableException(Exception exception) {
		Type = exception.GetType().Name;

		if (exception.InnerException != null)
			InnerException = new SerializableException(exception.InnerException);

		HelpLink = exception.HelpLink;
		HResult = exception.HResult;
		Message = exception.Message;
		Source = exception.Source;
		StackTrace = exception.StackTrace;

		var propertiesToExclude = new string[] {
			nameof(Type), nameof(InnerException), nameof(HelpLink), nameof(HResult), nameof(Message), nameof(Source), nameof(StackTrace), nameof(exception.TargetSite)
		};

		foreach (var propertyInfo in exception.GetType().GetProperties()) {
			if (propertiesToExclude.Any(p => p == propertyInfo.Name)) continue;
			if (propertyInfo.CanRead)
				Data.Add(propertyInfo.Name, propertyInfo.GetValue(exception));
		}
	}

	public SerializableException(SerializationInfo info, StreamingContext context) {
		Type = info.GetValue(nameof(Type), typeof(string)) as string;
		InnerException = info.GetValue(nameof(InnerException), typeof(SerializableException)) as SerializableException;
		HelpLink = info.GetValue(nameof(HelpLink), typeof(string)) as string;

		var hResult = info.GetValue(nameof(HResult), typeof(int));
		if (hResult != null) HResult = (int) hResult;

		Message = info.GetValue(nameof(Message), typeof(string)) as string;
		Source = info.GetValue(nameof(Source), typeof(string)) as string;
		StackTrace = info.GetValue(nameof(StackTrace), typeof(string)) as string;
		Data = info.GetValue(nameof(Data), typeof(IDictionary<string, object>)) as IDictionary<string, object>;
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context) {
		if (info == null) throw new ArgumentNullException(nameof(info));

		info.AddValue(nameof(Type), Type);
		info.AddValue(nameof(InnerException), InnerException);
		info.AddValue(nameof(HelpLink), HelpLink);
		info.AddValue(nameof(HResult), HResult);
		info.AddValue(nameof(Message), Message);
		info.AddValue(nameof(Source), Source);
		info.AddValue(nameof(StackTrace), StackTrace);
		info.AddValue(nameof(Data), Data);
	}
}