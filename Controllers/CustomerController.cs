using CRM.Data;
using CRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CRM.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CRMDbContext _context;

        public CustomerController(CRMDbContext context) => _context = context;
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get() => await _context.Customers.Include(x => x.CustomerAddress).ToListAsync();
        [HttpGet]
        public async Task<IActionResult> GetByID(int ID)
        {
            var Customer = await _context.Customers.Include(x=>x.CustomerAddress).FirstOrDefaultAsync(x=>x.ID == ID);
            return Customer == null ? NotFound() : Ok(Customer);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Customer customer)
        {
            var result = await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByID),new {ID = result.Entity.ID} ,customer);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Customer customer)
        {
            var model = await _context.Customers.Include(x => x.CustomerAddress).FirstOrDefaultAsync(x => x.ID == customer.ID); ;
            if (model == null)
                return NotFound();
            model.PhoneNumber = customer.PhoneNumber;
            model.FirstName = customer.FirstName;
            model.LastName = customer.LastName;
            model.Email = customer.Email;
            model.Code = customer.Code;
            model.CustomerAddress = customer.CustomerAddress;
            _context.Entry(model).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByID), new { ID = model.ID }, customer);
        }
        [HttpPut]
        public async Task<IActionResult> ChangeActivationStatus(int ID)
        {
            var model = await _context.Customers.FindAsync(ID);
            if (model == null)
                return NotFound();
            model.IsActive = !model.IsActive;
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByID), new { ID = model.ID }, model);
        }

    }
}
