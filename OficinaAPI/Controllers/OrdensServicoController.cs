using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OficinaAPI.Data;
using OficinaAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OficinaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdensServicoController : ControllerBase
    {
        private readonly OficinaContext _context;
        private readonly IMapper _mapper;

        public OrdensServicoController(OficinaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<OrdensServicoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ordens = await _context.OrdensServico.ToListAsync();
            return Ok(ordens);
        }

        // GET api/<OrdensServicoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var ordem = await _context.OrdensServico.FirstOrDefaultAsync(o => o.Id == id);
            if (ordem == null)
            {
                return NotFound("Ordem de serviço não encontrada!");
            }
            return Ok(ordem);
        }

        // POST api/<OrdensServicoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrdemServico novaOrdem)
        {
            if(novaOrdem == null)
            {
                return BadRequest("Dados inválidos");
            }
            var ordem = _mapper.Map<OrdemServico>(novaOrdem);
            ordem.Status = "Aberto";
            ordem.DataAbertura = DateTime.Now;
            await _context.OrdensServico.AddAsync(ordem);
            await _context.SaveChangesAsync();

            return Created("/ordensservico", ordem);
        }

        // PUT api/<OrdensServicoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id)
        {
            var ordem = await _context.OrdensServico.FirstOrDefaultAsync(o => o.Id == id);
            if(ordem == null)
            {
                return BadRequest("Ordem de serviço não encontrada!");
            }
            ordem.Status = "Fechada";
            ordem.DataFechamento = DateTime.Now;
            _context.Update(ordem);
            await _context.SaveChangesAsync();

            return Ok("Ordem de serviço atualizada com sucesso!");
        }

        // DELETE api/<OrdensServicoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var ordem = await _context.OrdensServico.FirstOrDefaultAsync(o => o.Id ==id);
            if(ordem == null)
            {
                return BadRequest("Ordem de serviço não encontrada!");
            }
            _context.Remove(ordem);
            await _context.SaveChangesAsync();
            return Ok("Ordem de serviço removida com sucesso!");
        }
    }
}
