namespace Kasp.Data.Models.Helpers {
	public interface IModel<TKey> {
		TKey Id { set; get; }
	}

	public interface IModel : IModel<int> {
	}
}