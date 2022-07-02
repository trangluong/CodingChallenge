using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommissionFactory.Entities
{
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }
        [Required]
        public Boolean Completed { get; set; }
        [Required]
        public string Details { get; set; }


    }
}
