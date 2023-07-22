using DashboardApiBack.BDContext;
using DashboardApiBack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DashboardApiBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DbContextDashboard _context;
        public CustomerController(DbContextDashboard context)
        {
            _context = context;
        }  

        [HttpGet]
        public IActionResult GetCustomer() { 
            var result= _context.Customers.ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerForId(int id)
        {
            var result = _context.Customers.Find(id);  
            return Ok(result);
        }

        [HttpPost("Añadir")]
        public IActionResult PostCustomer(Customer customer) { 
            if (customer == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return Ok("agregado");
            }
        }
    }
}
