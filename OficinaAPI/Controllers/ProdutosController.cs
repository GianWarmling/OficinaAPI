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
        public IActionResult Get()
        {
            var produtos = _context.Produtos.ToList();
            return Ok(produtos);
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
            {
                return NotFound("Produto não encontrado!");
            }
            return Ok(produto);
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public IActionResult Post([FromBody] ProdutoDTO novoProduto)
        {
            var produto = _mapper.Map<Produto>(novoProduto);
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Created("/produtos", produto);
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] ProdutoDTO produtoAtualizado)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

            if(produto == null)
            {
                return BadRequest("Produto não encontrado!");
            }
            _mapper.Map(produtoAtualizado, produto);
            _context.Update(produto);
            _context.SaveChanges();
            return Ok("Produto atualizado com sucesso!");
        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null) 
            {
                return BadRequest("Produto não encontrado!");
            }
            _context.Remove(produto);
            _context.SaveChanges();
            return Ok("Produto removido com sucesso!");
        }
    }
}
