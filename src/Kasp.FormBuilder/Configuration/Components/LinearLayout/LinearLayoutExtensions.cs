using System;

namespace Kasp.FormBuilder.Configuration.Components.LinearLayout {
	public static class LinearLayoutExtensions {
		public static ILinearLayoutConfiguration<TEntity> WithLinearLayout<TEntity>(this IConfigureBuilder<TEntity> builder, Action<ILinearLayoutConfiguration<TEntity>> builderAction) {
			return null;
		}
	}
}