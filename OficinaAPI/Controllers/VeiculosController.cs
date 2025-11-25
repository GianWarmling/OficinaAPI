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
        public async Task<IActionResult> Get()
        {
            var veiculos = await _context.Veiculos.ToListAsync();
            return Ok(veiculos);
        }

        // GET api/<VeiculosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var veiculo = await _context.Veiculos
                .Include(v => v.Cliente)
                .FirstOrDefaultAsync(v => v.Id == id);
            if (veiculo == null)
            {
                return NotFound("Veículo não encontrado!");
            }
            return Ok(veiculo);
        }

        // POST api/<VeiculosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VeiculoDTO novoVeiculo)
        {
            if (novoVeiculo == null)
            {
                return BadRequest("Dados Inválidos!");
            }

            var veiculo = _mapper.Map<Veiculo>(novoVeiculo);
            await _context.Veiculos.AddAsync(veiculo);
            await _context.SaveChangesAsync();
            return Created("/veiculos", veiculo);
        }

        // PUT api/<VeiculosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] VeiculoDTO veiculoAtualizado)
        {
            var veiculo = await _context.Veiculos.FirstOrDefaultAsync(v => v.Id == id);
            if (veiculo == null)
            {
                return BadRequest("Veículo não existe!");
            }
            _mapper.Map(veiculoAtualizado, veiculo);
            _context.Update(veiculo);
            await _context.SaveChangesAsync();
            return Ok("Veículo atualizado com sucesso!");
        }

        // DELETE api/<VeiculosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var veiculo = await _context.Veiculos.FirstOrDefaultAsync(v => v.Id == id);
            if (veiculo == null)
            {
                return BadRequest("Veículo não existe!");
            }
            _context.Remove(veiculo);
            await _context.SaveChangesAsync();
            return Ok("Veículo removido com sucesso!");
        }
    }
}
