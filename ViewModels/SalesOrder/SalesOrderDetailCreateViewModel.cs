using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CRM.ViewModels.SalesOrder
{
    public class SalesOrderDetailCreateViewModel
    {
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
