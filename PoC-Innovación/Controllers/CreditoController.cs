using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PoC_Innovación.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditoController : ControllerBase
    {
        private readonly ICreditoService _creditoService;
        public CreditoController(ICreditoService creditoService)
        {
            _creditoService = creditoService;
        }
        // GET: api/<CreditoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("GetCreditoList/{idCliente}")]
        public IEnumerable<CreditoDto> GetCreditoList(int idCliente)
        {
            return _creditoService.GetCreditoList(idCliente);
        }

        
        // GET api/<CreditoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CreditoController>
        [HttpPost]
        public IActionResult Post([FromBody] CreditoDto creditoDto)
        {
            try
            {
               _creditoService.RealizarCredito(creditoDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
          
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
