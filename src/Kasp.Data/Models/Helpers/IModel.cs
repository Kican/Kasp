using System;

namespace Kasp.Data.Models.Helpers {
	public interface IModel<TKey> where TKey : IEquatable<TKey> {
		TKey Id { set; get; }
	}

	public interface IModel : IModel<int> {
	}
}