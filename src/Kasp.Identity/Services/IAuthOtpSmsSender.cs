using System.Threading.Tasks;

namespace Kasp.Identity.Services {
	public interface IAuthOtpSmsSender {
		Task<SmsResult> SendSmsAsync(string phone, string code);
	}
	
	public class SmsResult {
		public bool isSuccess { get; set; }
		public string number { get; set; }
	}

}