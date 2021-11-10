namespace Kasp.Identity.Core.Entities.UserEntities.XEntities; 

public class PhoneRequestResponse {
	public PhoneRequestResponse(string senderNumber, bool isRegistered) {
		SenderNumber = senderNumber;
		IsRegistered = isRegistered;
	}
	public string SenderNumber { get; set; }
	public bool IsRegistered { get; set; }
}