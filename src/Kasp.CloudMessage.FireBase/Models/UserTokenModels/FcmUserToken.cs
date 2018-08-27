using System;
using System.ComponentModel.DataAnnotations;
using Kasp.Db.Models.Helpers;

namespace Kasp.CloudMessage.FireBase.Models.UserTokenModels {
	public class FcmUserToken : IModel, ICreateTime, IUpdateTime {
		public int Id { get; set; }

		public int UserId { get; set; }

		[MaxLength(300)]
		public string Token { get; set; }

		public DateTime CreateTime { get; set; }
		public DateTime? UpdateTime { get; set; }
	}
}