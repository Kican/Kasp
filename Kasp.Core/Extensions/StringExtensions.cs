namespace Kasp.Core.Extensions {
	public static class StringExtensions {
		public static string ToLowerCamelCase(this string theString) {
			return theString.Substring(0, 1).ToLower() + theString.Substring(1);
		}
	}
}