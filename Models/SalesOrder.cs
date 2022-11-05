using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models
{
    [Table("SalesOrder", Schema = "Order")]
    public class SalesOrder : BaseModel
    {
        [Required]

        public OrderStatus Status { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [ForeignKey("Customer")]
        [Required]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        [Required]
        public decimal Tax { get; set; } = 14;
        [Required]
        public decimal Subtotal { get; set; }
        [Required]
        public decimal GrandTotal { get; set; }
        [Required]
        [ForeignKey("ShippingAddress")]

        public int ShippingAddressID { get; set; }
        public virtual Address ShippingAddress { get; set; }
        [Required]
        [ForeignKey("BillingAddress")]
        public int BillingAddressID { get; set; }
        public virtual Address BillingAddress { get; set; }
    }
}
