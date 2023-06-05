using System.ComponentModel.DataAnnotations;

namespace InterestDb.Models.DTO
{
	public class InterestLinkDto
	{
		public int InterestLinkId { get; set; }
		[StringLength(200)]
		public string URL { get; set; }
		public int? FK_PersonId { get; set; }
		public int? FK_InterestId { get; set; }
	}
}
