using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models
{
    [Table("SalesOrderDetail", Schema = "Order")]
    public class SalesOrderDetail : BaseModel
    {
        [ForeignKey("SalesOrder")]
        public int OrderID { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
        public int LineNo { get; set; }
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public decimal LinePrice { get; set; }
        [Required]
        public int LineOrderQty { get; set; }
        [Required]
        public decimal LineTaxAmount { get; set; }
        [Required]
        public decimal LineTotal => LineOrderQty * LinePrice;
    }
}
