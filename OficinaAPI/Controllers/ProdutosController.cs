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
    public class ProdutosController : ControllerBase
    {
        private readonly OficinaContext _context;
        private readonly IMapper _mapper;

        public ProdutosController(OficinaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<ProdutosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var produtos = await _context.Produtos.ToListAsync();
            return Ok(produtos);
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

            if (produto == null)
            {
                return NotFound("Produto não encontrado!");
            }
            return Ok(produto);
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProdutoDTO novoProduto)
        {
            var produto = _mapper.Map<Produto>(novoProduto);
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
            return Created("/produtos", produto);
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] ProdutoDTO produtoAtualizado)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

            if(produto == null)
            {
                return BadRequest("Produto não encontrado!");
            }
            _mapper.Map(produtoAtualizado, produto);
            _context.Update(produto);
            await _context.SaveChangesAsync();
            return Ok("Produto atualizado com sucesso!");
        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

            if (produto == null) 
            {
                return BadRequest("Produto não encontrado!");
            }
            _context.Remove(produto);
            await _context.SaveChangesAsync();
            return Ok("Produto removido com sucesso!");
        }
    }
}
