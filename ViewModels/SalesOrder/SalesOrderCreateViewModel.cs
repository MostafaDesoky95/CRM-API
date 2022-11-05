using CRM.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CRM.ViewModels.SalesOrder
{
    public class SalesOrderCreateViewModel
    {
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public decimal Tax { get; set; } = 14;
        [Required]
        public decimal Subtotal { get; set; }
        [Required]
        public decimal GrandTotal { get; set; }
        [Required]
        public int ShippingAddressID { get; set; }
        [Required]
        public int BillingAddressID { get; set; }
        [Required]
        [JsonIgnore]
        public int OrderID { get; set; }
        [Required]
        public int LineNo { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public decimal LinePrice { get; set; }
        [Required]
        public int LineOrderQty { get; set; }
        [Required]
        public decimal LineTaxAmount { get; set; }
        [Required]
        [JsonIgnore]
        public decimal LineTotal => LineOrderQty * LinePrice;
    }
}
