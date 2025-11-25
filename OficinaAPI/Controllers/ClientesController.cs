using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Get()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return Ok(clientes);
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado!");
            }
            return Ok(cliente);
        }

        // POST api/<ClientesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDTO novoCliente)
        {
            if (novoCliente == null)
            {
                return BadRequest("Dados inválidos!");
            }
            var cliente = _mapper.Map<Cliente>(novoCliente);
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return Created("/clientes", cliente);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody] ClienteDTO clienteAtualizado)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            if (cliente == null)
            {
                return BadRequest("Cliente não existe!");
            }
            _mapper.Map(clienteAtualizado, cliente);
            _context.Update(cliente);
            await _context.SaveChangesAsync();
            return Ok("Cliente atualizado com sucesso!");
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            if (cliente == null)
            {
                BadRequest("Cliente não encontrado!");
            }
            _context.Remove(cliente);
            await _context.SaveChangesAsync();
            return Ok("Cliente removido com sucesso!");
        }
    }
}
