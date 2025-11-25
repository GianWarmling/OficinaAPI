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
    public class ServicosController : ControllerBase
    {
        private readonly OficinaContext _context;
        private readonly IMapper _mapper;

        public ServicosController(OficinaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<ServicosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var servicos = await _context.Servicos.ToListAsync();
            return Ok(servicos);
        }

        // GET api/<ServicosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var servico = await _context.Servicos.FirstOrDefaultAsync(s => s.Id == id);
            if (servico == null)
            {
                return NotFound("Serviço não encontrado!");
            }
            return Ok(servico);
        }

        // POST api/<ServicosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ServicoDTO novoServico)
        {
            var servico = _mapper.Map<Servico>(novoServico);
            await _context.Servicos.AddAsync(servico);
            await _context.SaveChangesAsync();
            return Created("/servicos", servico);
        }

        // PUT api/<ServicosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody] ServicoDTO servicoAtualizado)
        {
            var servico = await _context.Servicos.FirstOrDefaultAsync(s => s.Id == id);
            if(servico == null)
            {
                return BadRequest("Serviço não encontrado!");
            }
            _mapper.Map(servicoAtualizado, servico);
            _context.Update(servico);
            await _context.SaveChangesAsync();
            return Ok("Serviço atualizado com sucesso!");
        }

        // DELETE api/<ServicosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var servico = await _context.Servicos.FirstOrDefaultAsync(s => s.Id == id);
            if (servico == null)
            {
                return BadRequest("Serviõ não encontrado!");
            }
            _context.Remove(servico);
            await _context.SaveChangesAsync();
            return Ok("Serviço removido com sucesso!");
        }
    }
}
