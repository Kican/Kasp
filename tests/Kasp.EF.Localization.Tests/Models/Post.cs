using System.ComponentModel.DataAnnotations;
using Kasp.EF.Localization.Models;
using Kasp.EF.Localization.Models.Helpers;
using Kasp.EF.Models.Helpers;

namespace Kasp.EF.Localization.Tests.Models {
	public class Post : IModel, ILocalizer {
		public int Id { get; set; }

		public Lang Lang { get; set; }
		public string LangId { get; set; }

		[MaxLength(100)]
		public string Title { get; set; }
	}
}