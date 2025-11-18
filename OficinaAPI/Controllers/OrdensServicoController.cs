using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Get()
        {
            var ordens = _context.OrdensServico.ToList();
            return Ok(ordens);
        }

        // GET api/<OrdensServicoController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var ordem = _context.OrdensServico.FirstOrDefault(o => o.Id == id);
            if (ordem == null)
            {
                return NotFound("Ordem de serviço não encontrada!");
            }
            return Ok(ordem);
        }

        // POST api/<OrdensServicoController>
        [HttpPost]
        public IActionResult Post([FromBody] OrdemServico novaOrdem)
        {
            if(novaOrdem == null)
            {
                return BadRequest("Dados inválidos");
            }
            var ordem = _mapper.Map<OrdemServico>(novaOrdem);
            ordem.Status = "Aberto";
            ordem.DataAbertura = DateTime.Now;
            _context.OrdensServico.Add(ordem);
            _context.SaveChanges();

            return Created("/ordensservico", ordem);
        }

        // PUT api/<OrdensServicoController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id)
        {
            var ordem = _context.OrdensServico.FirstOrDefault(o => o.Id == id);
            if(ordem == null)
            {
                return BadRequest("Ordem de serviço não encontrada!");
            }
            ordem.Status = "Fechada";
            ordem.DataFechamento = DateTime.Now;
            _context.Update(ordem);
            _context.SaveChanges();

            return Ok("Ordem de serviço atualizada com sucesso!");
        }

        // DELETE api/<OrdensServicoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var ordem = _context.OrdensServico.FirstOrDefault(o => o.Id ==id);
            if(ordem == null)
            {
                return BadRequest("Ordem de serviço não encontrada!");
            }
            _context.Remove(ordem);
            _context.SaveChanges();
            return Ok("Ordem de serviço removida com sucesso!");
        }
    }
}
