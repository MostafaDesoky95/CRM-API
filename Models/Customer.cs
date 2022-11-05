using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models
{
    [Table("Customer", Schema = "Customer")]
    public class Customer : BaseModel
    {
        [Required]
        public string Code { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<Address> CustomerAddress { get; set; }
    }
}
