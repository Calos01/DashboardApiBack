using DashboardApiBack.BDContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardApiBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DbContextDashboard _context;
        public OrderController(DbContextDashboard context)
        {
                _context = context;
        }

        [HttpGet("Stados")]
        public IActionResult GetOrder() { 
            var orders=_context.Pedidos.Include(x=>x.Customer).ToList();

            var group = orders.GroupBy(y => y.Customer.State).ToList().Select(grp =>new
            {
                State= grp.Key,
                Total= grp.Sum(x=>x.Total)
            }).OrderByDescending(r=>r.Total).ToList();
            return Ok(group);
        }

    }
}
