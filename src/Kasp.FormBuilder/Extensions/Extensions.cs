using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kasp.FormBuilder.Extensions; 

public static class Extensions {
	public static string GetDisplayName(this PropertyInfo model) {
		var name = "";

		var attr = model.GetCustomAttribute<DisplayAttribute>();

		if (attr == null) {
			var attr2 = model.GetCustomAttribute<DisplayNameAttribute>();
			if (attr2 != null)
				name = attr2.DisplayName;
		}
		else
			name = attr.Name;

		return !string.IsNullOrEmpty(name) ? name : model.Name;
	}

	public static string GetDisplayName(this Type model) {
		var name = "";

		var attr = model.GetCustomAttribute<DisplayAttribute>();

		if (attr == null) {
			var attr2 = model.GetCustomAttribute<DisplayNameAttribute>();
			if (attr2 != null)
				name = attr2.DisplayName;
		}
		else
			name = attr.Name;

		return !string.IsNullOrEmpty(name) ? name : model.Name;
	}

	public static string GetDisplayName(this FieldInfo model) {
		var name = "";

		var attr = model.GetCustomAttribute<DisplayAttribute>();

		if (attr == null) {
			var attr2 = model.GetCustomAttribute<DisplayNameAttribute>();
			if (attr2 != null)
				name = attr2.DisplayName;
		}
		else
			name = attr.Name;

		return !string.IsNullOrEmpty(name) ? name : model.Name;
	}

	public static string GetString(this TagBuilder content) {
		var writer = new StringWriter();
		content.WriteTo(writer, HtmlEncoder.Default);
		return writer.ToString();
	}

	public static bool IsNumberic(this Type type) {
		switch (Type.GetTypeCode(type)) {
			case TypeCode.Byte:
			case TypeCode.Decimal:
			case TypeCode.Double:
			case TypeCode.Int16:
			case TypeCode.Int32:
			case TypeCode.Int64:
			case TypeCode.SByte:
			case TypeCode.Single:
			case TypeCode.UInt16:
			case TypeCode.UInt32:
			case TypeCode.UInt64:
				return true;
			default:
				return false;
		}
	}
}