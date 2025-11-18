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
        public IActionResult Get()
        {
            var servicos = _context.Servicos.ToList();
            return Ok(servicos);
        }

        // GET api/<ServicosController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var servico = _context.Servicos.FirstOrDefault(s => s.Id == id);
            if (servico == null)
            {
                return NotFound("Serviço não encontrado!");
            }
            return Ok(servico);
        }

        // POST api/<ServicosController>
        [HttpPost]
        public IActionResult Post([FromBody] ServicoDTO novoServico)
        {
            var servico = _mapper.Map<Servico>(novoServico);
            _context.Servicos.Add(servico);
            _context.SaveChanges();
            return Created("/servicos", servico);
        }

        // PUT api/<ServicosController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody] ServicoDTO servicoAtualizado)
        {
            var servico = _context.Servicos.FirstOrDefault(s => s.Id == id);
            if(servico == null)
            {
                return BadRequest("Serviço não encontrado!");
            }
            _mapper.Map(servicoAtualizado, servico);
            _context.Update(servico);
            _context.SaveChanges();
            return Ok("Serviço atualizado com sucesso!");
        }

        // DELETE api/<ServicosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var servico = _context.Servicos.FirstOrDefault(s => s.Id == id);
            if (servico == null)
            {
                return BadRequest("Serviõ não encontrado!");
            }
            _context.Remove(servico);
            _context.SaveChanges();
            return Ok("Serviço removido com sucesso!");
        }
    }
}
