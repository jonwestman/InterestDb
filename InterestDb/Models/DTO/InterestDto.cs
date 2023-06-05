using System.ComponentModel.DataAnnotations;

namespace InterestDb.Models.DTO
{
	public class InterestDto
	{
		public int InterestId { get; set; }
		[Required]
		[StringLength(30)]
		public string Title { get; set; }
		[Required]
		[StringLength(500)]
		public string Description { get; set; }
	}
}
