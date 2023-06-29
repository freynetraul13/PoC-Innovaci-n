using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PoC_Innovación.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComercioController : ControllerBase
    {
        public readonly IComercioService ComercioService;
        public ComercioController(IComercioService comercioService)
        {
            ComercioService = comercioService;
        }
        // GET: api/<CreditoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CreditoController>/5
        [HttpGet("{id}")]
        public ComercioDto Get(int id)
        {
            return ComercioService.ObtenerComercio(id);
        }

        // POST api/<CreditoController>
        [HttpPost]
        public void Post([FromBody] ComercioDto comercio)
        {
            ComercioService.CrearComercio(comercio);
        }

        // PUT api/<CreditoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CreditoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
