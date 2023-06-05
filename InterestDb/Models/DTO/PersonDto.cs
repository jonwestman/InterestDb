using System.ComponentModel.DataAnnotations;

namespace InterestDb.Models.DTO
{
	public class PersonDto
	{
		public int PersonId { get; set; }
		[Required]
		[StringLength(30)]
		public string FirstName { get; set; }
		[Required]
		[StringLength(30)]
		public string LastName { get; set; }
		[StringLength(50)]
		public string Adress { get; set; }
		[StringLength(30)]
		public string PhoneNumber { get; set; }
		[Required]
		[StringLength(50)]
		public string Email { get; set; }
	}
}
