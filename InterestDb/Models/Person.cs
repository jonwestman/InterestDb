using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterestDb.Models
{
	public class Person
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
		ICollection<Interest>Interests { get; set; }
		ICollection<InterestLink> InterestLinks { get; set; }


	}
}
