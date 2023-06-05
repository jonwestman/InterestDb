using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterestDb.Models
{
	public class Interest
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InterestId { get; set; }
        [Required]
        [StringLength(30)]
        public string Title { get; set; }
		[Required]
		[StringLength(500)]
		public string Description { get; set; }
        ICollection<InterestLink> InterestLinks { get; set; }
    }
}
