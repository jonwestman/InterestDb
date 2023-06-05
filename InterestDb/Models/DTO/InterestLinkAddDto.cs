using System.ComponentModel.DataAnnotations;

namespace InterestDb.Models.DTO
{
	public class InterestLinkAddDto
	{
		[StringLength(200)]
		public string URL { get; set; }
		public int? FK_PersonId { get; set; }
		public int? FK_InterestId { get; set; }
	}
}
