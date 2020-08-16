namespace Kasp.Data.Models {
	public class FilterBase : IPage, IOrder {
		public int Page { get; set; } = 1;
		public int Count { get; set; } = 10;

		public string OrderBy { get; set; }
		public bool IsDesc { get; set; }

		public string Q { get; set; }
	}
}