using System.ComponentModel.DataAnnotations;
using Kasp.Data.EF.Models.Helpers;
using Kasp.Localization.EF.Models;
using Kasp.Localization.EF.Models.Helpers;

namespace Kasp.Localization.EF.Tests.Models {
	public class Post : IModel, ILocalizer {
		public int Id { get; set; }

		public Lang Lang { get; set; }
		public string LangId { get; set; }

		[MaxLength(100)]
		public string Title { get; set; }
	}
}