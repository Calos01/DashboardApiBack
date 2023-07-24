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
        [HttpGet("GetOrder/{id}")]
        public IActionResult GetOrder(int id)
        {
            //Cone el include se jala los objetos
            var orders = _context.Pedidos.Include(x=>x.Customer).ToList();
            var res = orders.Where(x => x.Id == id).FirstOrDefault();

            return Ok(res);
        }

        [HttpGet("TotalbyEstados")]
        public IActionResult GetOrderByStates() {
            //En la migracion el atributo Customer del modelo Pedido paso a ser CustomerId en la bd
            var orders =_context.Pedidos.Include(x=>x.Customer).ToList();
            
            //Con select agruparemos como si estuvieramos creando una vista
            var res = orders.GroupBy(x => x.Customer.State).ToList().Select(grp =>new
            {   //Creamos lo q mostrara la api Estados tendra una key igual que status y Total tendra la suma de los totales de los pedidos
                //grp.Key es el valor con qien estas agrupando este caso es Customer.State
                Estados=grp.Key,
                Total=grp.Sum(x=>x.Total),
            }).OrderByDescending(x=>x.Total).ToList();

            return Ok(res);
        }

        [HttpGet("TotalbyCustomers/{n}")]
        public IActionResult TotalbyCustomers(int n)
        {
            //En la migracion el atributo Customer del modelo Pedido paso a ser CustomerId en la bd
            var orders = _context.Pedidos.Include(x => x.Customer).ToList();

            //Con select agruparemos como si estuvieramos creando una vista
            var res = orders.GroupBy(x => x.Customer.Id).ToList().Select(grp => new
            {   
                //grp.Key es el valor con qien estas agrupando este caso es Customer.Id
                names = _context.Customers.Find(grp.Key).Name,
                Total = grp.Sum(x => x.Total),
            }).OrderByDescending(x => x.Total).Take(n).ToList();

            return Ok(res);
        }

        //paginacion
        [HttpGet("{page}/{pageSize}")]
        public IActionResult Get(int page, int pageSize)
        {
            var pedidos=_context.Pedidos.Include(x => x.Customer).ToList();
            // Aplicar paginación a la lista de datos.
            var paginatedData = pedidos.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(paginatedData);
        }

    }
}
