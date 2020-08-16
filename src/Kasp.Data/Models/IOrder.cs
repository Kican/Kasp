namespace Kasp.Data.Models {
	public interface IOrder {
		string OrderBy { get; set; }
		bool IsDesc { get; set; }
	}
}