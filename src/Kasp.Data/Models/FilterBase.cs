namespace Kasp.Data.Models {
	public class FilterBase : IPage, IOrder {
		public int Page { get; set; }
		public int Count { get; set; }
		
		public string OrderBy { get; set; }
		public bool IsDesc { get; set; }

		public string Q { get; set; }
	}
}