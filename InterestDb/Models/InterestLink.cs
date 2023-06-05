using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterestDb.Models
{
	public class InterestLink
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InterestLinkId { get; set; }
        [StringLength(200)]
        public string? URL { get; set; }
        [ForeignKey(nameof(Person))]
        public int FK_PersonId { get; set; }
        public Person Person { get; set; }
        [ForeignKey(nameof(Interest))]
        public int FK_InterestId { get; set; }
        public Interest Interest { get; set; }
    }
}
