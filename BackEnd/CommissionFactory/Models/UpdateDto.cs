using System.ComponentModel;

namespace CommissionFactory.Models
{
    public class UpdateDto
    {
        public string? Details { get; set; }

        [DefaultValue(false)]
        public Boolean Completed { get; set; }
    }
}
