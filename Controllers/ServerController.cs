using DashboardApiBack.BDContext;
using DashboardApiBack.Models;
using Microsoft.AspNetCore.Mvc;

namespace DashboardApiBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerController : Controller
    {
        private readonly DbContextDashboard _context;

        public ServerController(DbContextDashboard context)
        {
            _context = context;
        }

        [HttpGet("GetServers")]
        public IActionResult GetServers()
        {
            var res=_context.Servers.OrderBy(x => x.Id).ToList();
            return Ok(res);
        }

        [HttpGet("GetServer/{id}")]
        public IActionResult GetServer(int id)
        {
            var res = _context.Servers.Find(id);
            return Ok(res);
        }

        //Modificar el activo o inactivo al server por id
        [HttpPut("Server/{id}")]
        public IActionResult PutMessage(int id, [FromBody] ServerMessage msg) 
        {
            var server = _context.Servers.Find(id);

            if (server == null)
            {
                return BadRequest();
            }
            else
            {
                if (msg.Payload == "activo")
                {
                    server.Online = true;
                }
                else if (msg.Payload == "inactivo")
                {
                    server.Online = false;
                }
                _context.SaveChanges();
            }
            return Ok(msg.Payload);
        }
    }
}
