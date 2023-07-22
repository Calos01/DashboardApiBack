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

            
            return Ok(orders);
        }

        [HttpGet("{page}/{pageSize}")]
        public IActionResult Get(int page, int pageSize)
        {
            // Aplicar paginación a la lista de datos.
            var paginatedData = _context.Pedidos.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(paginatedData);
        }
    }
}
