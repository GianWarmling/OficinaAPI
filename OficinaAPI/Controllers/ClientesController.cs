using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OficinaAPI.Data;
using OficinaAPI.Models;
using OficinaAPI.Models.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OficinaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly OficinaContext _context;
        private readonly IMapper _mapper;

        public ClientesController(OficinaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<ClientesController>
        [HttpGet]
        public IActionResult Get()
        {
            var clientes = _context.Clientes.ToList();
            return Ok(clientes);
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado!");
            }
            return Ok(cliente);
        }

        // POST api/<ClientesController>
        [HttpPost]
        public IActionResult Post([FromBody] ClienteDTO novoCliente)
        {
            if (novoCliente == null)
            {
                return BadRequest("Dados inválidos!");
            }
            var cliente = _mapper.Map<Cliente>(novoCliente);
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return Created("/clientes", cliente);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody] ClienteDTO clienteAtualizado)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return BadRequest("Cliente não existe!");
            }
            _mapper.Map(clienteAtualizado, cliente);
            _context.Update(cliente);
            _context.SaveChanges();
            return Ok("Cliente atualizado com sucesso!");
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                BadRequest("Cliente não encontrado!");
            }
            _context.Remove(cliente);
            _context.SaveChanges();
            return Ok("Cliente removido com sucesso!");
        }
    }
}
