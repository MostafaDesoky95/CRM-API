using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models
{
    [Table("Address", Schema = "Address")]
    public class Address : BaseModel
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public bool IsShippingAddress { get; set; }
        public bool IsBillingAddress { get; set; }
    }
}
