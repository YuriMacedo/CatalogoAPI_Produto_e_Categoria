using APICatalogo.Context;
using APICatalogo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get() 
        {
            var produtos = _context.Produtos.AsNoTracking().Take(10).ToList();
            
            if (produtos is null)
            {
                return NotFound("Nenhum produto encontrado...");
            }
            return produtos;

        }

        [HttpGet("{id:int}",Name = "ObterProduto")]
        public ActionResult<Produto> GetProdutoById(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Produto não encontrado");
            }
            return produto;
        }

        [HttpPost]
        public ActionResult CadastraProduto(Produto produto) 
        {
            if (produto is null)
            {
                return BadRequest();
            }
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId},produto);

        }

        [HttpPut("{id:int}")]
        public ActionResult AtualizaProduto(int id, Produto produto) 
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(produto);

        }

        [HttpDelete("{id:int}")]
        public ActionResult DeletaProduto(int id) 
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId==id);
            if (produto is null)
            {
                return NotFound("Produto não encontrado");
            }
            _context.Remove(produto);
            _context.SaveChanges();
            return Ok(produto);
            
            
        }

        
    }
}
