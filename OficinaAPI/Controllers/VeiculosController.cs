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
    public class VeiculosController : ControllerBase
    {
        private readonly OficinaContext _context;
        private readonly IMapper _mapper;

        public VeiculosController(OficinaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<VeiculosController>
        [HttpGet]
        public IActionResult Get()
        {
            var veiculos = _context.Veiculos.ToList();
            return Ok(veiculos);
        }

        // GET api/<VeiculosController>/5
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var veiculo = _context.Veiculos.FirstOrDefault(v => v.Id == id);
            if (veiculo == null)
            {
                return NotFound("Veículo não encontrado!");
            }
            return Ok(veiculo);
        }

        // POST api/<VeiculosController>
        [HttpPost]
        public IActionResult Post([FromBody] VeiculoDTO novoVeiculo)
        {
            var veiculo = _mapper.Map<Veiculo>(novoVeiculo);
            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();
            return Created("/veiculos", veiculo);
        }

        // PUT api/<VeiculosController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] VeiculoDTO veiculoAtualizado)
        {
            var veiculo = _context.Veiculos.FirstOrDefault(v => v.Id == id);
            if (veiculo == null)
            {
                return BadRequest("Veículo não existe!");
            }
            _mapper.Map(veiculoAtualizado, veiculo);
            _context.Update(veiculo);
            _context.SaveChanges();
            return Ok("Veículo atualizado com sucesso!");
        }

        // DELETE api/<VeiculosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var veiculo = _context.Veiculos.FirstOrDefault(v => v.Id == id);
            if (veiculo == null)
            {
                return BadRequest("Veículo não existe!");
            }
            _context.Remove(veiculo);
            _context.SaveChanges();
            return Ok("Veículo removido com sucesso!");
        }
    }
}
