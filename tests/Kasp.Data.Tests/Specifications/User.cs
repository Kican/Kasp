using System;
using Kasp.Data.Models.Helpers;

namespace Kasp.Data.Test.Specifications {
	public class User : IModel,ICreateTime,IEnable{
		public int Id { get; set; }

		public string Name { get; set; }
		public int CityId { get; set; }
		public int Age { get; set; }

		public DateTimeOffset CreateTime { get; set; }
		public bool Enable { get; set; }
	}
}
