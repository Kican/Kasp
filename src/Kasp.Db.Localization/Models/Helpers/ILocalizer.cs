using System.ComponentModel.DataAnnotations;

namespace Kasp.Db.Localization.Models.Helpers {
	public interface ILocalizer {
		Lang Lang { get; set; }

		// todo: must all of entity have same MaxLength
		[MaxLength(10)]
		string LangId { get; set; }
	}
}