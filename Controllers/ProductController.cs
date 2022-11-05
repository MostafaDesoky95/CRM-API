using CRM.Data;
using CRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CRMDbContext _context;

        public ProductController(CRMDbContext context) => _context = context;
        [HttpGet]
        public async Task<IEnumerable<Product>> Get() => await _context.Products.ToListAsync();
        [HttpGet]
        public async Task<IActionResult> GetByID(int ID)
        {
            var Product = await _context.Products.FirstOrDefaultAsync(x => x.ID == ID);
            return Product == null ? NotFound() : Ok(Product);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            var result = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByID), new { ID = result.Entity.ID }, product);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            var model = await _context.Products.FirstOrDefaultAsync(x => x.ID == product.ID); ;
            if (model == null)
                return NotFound();
            model.Description = product.Description;
            model.Name = product.Name;
            model.Price = product.Price;

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByID), new { ID = model.ID }, product);
        }
    }
}
