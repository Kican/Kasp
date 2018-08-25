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
	}
}