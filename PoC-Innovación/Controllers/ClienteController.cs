using Application.DTO;
using Application.Interfaces;
using Domain;
using Infraestructure;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PoC_Innovación.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly IClienteService _clienteService;
        // GET: api/<CreditoController>
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // POST api/<CreditoController>
        [HttpPost]
        public void Post([FromBody] ClienteDTO cliente)
        {           
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
