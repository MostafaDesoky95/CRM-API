using CRM.Data;
using CRM.Models;
using CRM.ViewModels.SalesOrder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        private readonly CRMDbContext _context;

        public SalesOrderController(CRMDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<SalesOrder>> Get() => await _context.SalesOrders.ToListAsync();
        [HttpGet]
        public async Task<IActionResult> GetByID(int ID)
        {
            var SalesOrder = await _context.SalesOrders.FirstOrDefaultAsync(x => x.ID == ID);
            return SalesOrder == null ? NotFound() : Ok(SalesOrder);
        }
        [HttpPost]
        public async Task<IActionResult> Post(SalesOrderCreateViewModel order)
        {
            var salesOrder = new SalesOrder()
            {
                BillingAddressID = order.BillingAddressID,
                CustomerID = order.CustomerID,
                Date = order.Date,
                Subtotal = order.Subtotal,
                GrandTotal = order.GrandTotal,
                ShippingAddressID = order.ShippingAddressID
            };
            var result = await _context.SalesOrders.AddAsync(salesOrder);
            await _context.SaveChangesAsync();
            var orderDetail = new SalesOrderDetail()
            {
                LineNo = order.LineNo,
                LineOrderQty = order.LineOrderQty,
                LinePrice = order.LinePrice,
                LineTaxAmount = order.LineTaxAmount,
                OrderID = result.Entity.ID,
                ProductID = order.ProductID,
            };
            await _context.SalesOrderDetails.AddAsync(orderDetail);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByID), new { ID = result.Entity.ID }, order);
        }
        [HttpPut]
        public async Task<IActionResult> CancelOrder(int ID)
        {
            var SalesOrder = await _context.SalesOrders.FirstOrDefaultAsync(x => x.ID == ID);
            if (SalesOrder == null) return NotFound();
            SalesOrder.Status = OrderStatus.Canceled;
            _context.Entry(SalesOrder).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByID), new { ID = ID }, SalesOrder);
        }
    }
}
