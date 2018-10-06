using System;
using Microsoft.Extensions.Configuration;

namespace Kasp.EF.Tests {
	public class EfTestConfig {
		public static string GetConnectionString() {
			var connectionString = "Server=localhost;Database=KaspTest;User Id=postgres;Password=123456;";
			if (Environment.GetEnvironmentVariable("APPVEYOR") != null)
				connectionString = "Server=localhost;Database=KaspTest;User Id=postgres;Password=Password12!;";

			return connectionString;
		}
	}
}