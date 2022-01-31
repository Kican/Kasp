using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Kasp.Core.Extensions; 

public static class StringExtensions {
	public static string ToLowerCamelCase(this string theString) {
		return theString.Substring(0, 1).ToLower() + theString.Substring(1);
	}

	public static string ToSlug(this string s) {
		var str = s.RemoveDiacritics();

		str = Regex.Replace(str, @"(\B[A-Z]+?(?=[A-Z][^A-Z])|\B[A-Z]+?(?=[^A-Z]))", " $1");
		str = str.ToLower();

		str = Regex.Replace(str, @"[^a-z0-9\s-]", "");

		str = Regex.Replace(str, @"\s+", " ").Trim();

		str = str.Trim();
		str = Regex.Replace(str, @"\s", "-");
		return str;
	}

	public static string RemoveDiacritics(this string s) {
		var normalizedString = s.Normalize(NormalizationForm.FormD);
		var stringBuilder = new StringBuilder();

		foreach (var c in normalizedString) {
			var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
			if (unicodeCategory != UnicodeCategory.NonSpacingMark) {
				stringBuilder.Append(c);
			}
		}

		return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
	}
}