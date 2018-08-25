using System;
using System.IO;

namespace Kasp.CloudMessage.FireBase.Settings {
	public class FcmClientSettings {
		public string Project { get; }
		public string Credentials { get; }

		public FcmClientSettings(string project, string credentials) {
			Project = project;
			Credentials = credentials;
		}

		public static FcmClientSettings ReadFromFile(string project, string credentialsFileName) {
			return new FcmClientSettings(project, ReadCredentialsFromFile(credentialsFileName));
		}

		public static FcmClientSettings ReadFromStream(string project, Stream credentialsStream) {
			var credentials = ReadCredentialsFromStream(credentialsStream);
			return new FcmClientSettings(project, credentials);
		}

		private static string ReadCredentialsFromStream(Stream credentialStream) {
			if (credentialStream == null)
				throw new ArgumentNullException("credentialStream");

			if (!credentialStream.CanRead)
				throw new ArgumentException("Cannot read from the given stream", "credentialStream");

			using (var reader = new StreamReader(credentialStream)) {
				return reader.ReadToEnd();
			}
		}
		
		private static string ReadCredentialsFromFile(string fileName) {
			if (fileName == null)
				throw new ArgumentNullException("fileName");

			if (!File.Exists(fileName))
				throw new Exception($"Could not Read Credentials. (Reason = File Does Not Exist, FileName = '{fileName}')");


			var credentials = File.ReadAllText(fileName);

			if (string.IsNullOrWhiteSpace(credentials))
				throw new Exception($"Could not Read Credentials. (Reason = File Is Empty, FileName = '{fileName}')");

			return credentials;
		}
	}
}