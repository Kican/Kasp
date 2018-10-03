namespace Kasp.Data.Models {
	public interface ISort {
		string Name { get; set; }
		SortDirection Dir { get; set; }
	}

	public enum SortDirection {
		Asc = 0,
		Desc = 1
	}
}