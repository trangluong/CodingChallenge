using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CommissionFactory.Models
{
    public class CreateDto
    {
        [Required]
        [DefaultValue("")]
        public string Details { get; set; }

        [DefaultValue(false)]
        public Boolean Completed { get; set; }  
    }
}
