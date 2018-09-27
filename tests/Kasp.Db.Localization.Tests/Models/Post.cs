using System.ComponentModel.DataAnnotations;
using Kasp.Db.Localization.Models;
using Kasp.Db.Localization.Models.Helpers;
using Kasp.Db.Models.Helpers;

namespace Kasp.Db.Localization.Tests.Models {
	public class Post : IModel, ILocalizer {
		public int Id { get; set; }

		public Lang Lang { get; set; }
		public string LangId { get; set; }

		[MaxLength(100)]
		public string Title { get; set; }
	}
}