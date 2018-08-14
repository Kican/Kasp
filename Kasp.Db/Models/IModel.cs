namespace Kasp.Db.Models {
	public interface IModel<TKey> {
		TKey Id { set; get; }
	}

	public interface IModel : IModel<int> {
        
	}
}