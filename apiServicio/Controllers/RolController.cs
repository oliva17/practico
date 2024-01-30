using apiServicio.Models;
using apiServicio.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiServicio.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RolController : ControllerBase
    {
        private readonly IRolService _IRolService;

        public RolController(IRolService temp)
        {
            this._IRolService = temp;
            Console.WriteLine($"IRolService resuelto: {_IRolService}");
        }

        [HttpGet]
        public async Task<ActionResult<List<Rol>>> GetList()
        {
            try
            {
                var roles = await _IRolService.GetList();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                // Puedes loggear el error o devolver un resultado específico para errores
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpPost("AgregaActualiza")]
        public async Task<Rol> AgregaActualiza(
            int Id, string NombreRol, string t)
        {
            Rol l = new Rol();
            l.Id = Id;
            l.NombreRol = NombreRol;
            return await _IRolService.AgregaActualiza(l,t);

        }
    }
}
