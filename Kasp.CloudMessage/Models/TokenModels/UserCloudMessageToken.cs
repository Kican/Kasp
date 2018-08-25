using System;
using System.ComponentModel.DataAnnotations;
using Kasp.Db.Models.Helpers;

namespace Kasp.CloudMessage.Models.TokenModels {
	public class UserCloudMessageToken : IModel, ICreateTime {
		public int Id { get; set; }

		[MaxLength(400)]
		public string Token { get; set; }

		public int UserId { get; set; }
		
		public DateTime CreateTime { get; set; }
	}
}