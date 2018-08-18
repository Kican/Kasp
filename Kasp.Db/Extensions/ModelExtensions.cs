using System;
using Kasp.Db.Models;
using Kasp.Db.Models.Helpers;

namespace Kasp.Db.Extensions {
	public static class ModelExtensions {
		public static void Update(this IUpdateTime model) {
			model.UpdateTime = DateTime.UtcNow;
		}

		public static void Create(this ICreateTime model) {
			model.CreateTime = DateTime.UtcNow;
		}

		public static void SoftDelete(this ISoftDelete model) {
			model.SoftDelete = DateTime.UtcNow;
		}
	}
}