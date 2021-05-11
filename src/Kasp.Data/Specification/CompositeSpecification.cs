namespace Kasp.Data.Specification {
	public abstract class CompositeSpecification<T> : Specification<T>, ICompositeSpecification<T> {
		protected CompositeSpecification(ISpecification<T> left, ISpecification<T> right) {
			Left = left;
			Right = right;
		}

		public ISpecification<T> Left { get; }
		public ISpecification<T> Right { get; }
	}
}
