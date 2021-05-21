namespace Kasp.Data.Specification {
	public static class SpecificationExtensions {
		public static Specification<T> And<T>(this ISpecification<T> specification, ISpecification<T> other) {
			return new AndSpecification<T>(specification, other);
		}

		public static Specification<T> Or<T>(this ISpecification<T> specification, ISpecification<T> other) {
			return new OrSpecification<T>(specification, other);
		}

		public static Specification<T> AndNot<T>(this ISpecification<T> specification, ISpecification<T> other) {
			return new AndNotSpecification<T>(specification, other);
		}

		public static Specification<T> Not<T>(this ISpecification<T> specification) {
			return new NotSpecification<T>(specification);
		}
	}
}
