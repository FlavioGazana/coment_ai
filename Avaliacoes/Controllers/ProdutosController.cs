using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Avaliacoes.Database; //esse usign garante o acesso do controller ao nosso db context
using Avaliacoes.DTO;
using Avaliacoes.Models;

namespace Avaliacoes.Controllers
{
    [Route("api/[controller]")] //esse comando serve para definir a rota na qual o
    //controller será acessado, no caso, irá subistituir o [controller] pelo nome do arquivo

    [ApiController] //esse comando indica que os dados retornados pelo controller se conterão apenas a dados e não view(front-end)
    //além disso, ele validará automaticamente os dados enviados pelo usuário retornando um status 400(erro) de forma automática

    [Authorize] //esse comando garante que apenas usuários autorizados terão acesso a esse controller

    public class ProdutosController : Controller
    {
        private readonly AvaDbContext dbContext; //esse o parâmetro necessário para a injeção da dependência do banco de dados

        public ProdutosController(AvaDbContext dbContext) //esse é o construtor responsável pela injeção da dependência, no caso, para que o nosso controller
            //possa ter acesso ao banco quase irrestrito ao banco de dados, podendo fazer crud completo
        {
            this.dbContext = dbContext;
        }

        [HttpGet] //indicador de requisição get (extração de dados)
        public ActionResult<IEnumerable<Produto>> GetProdutos() //metódo para retornar todos os produtos
        {
            return Ok(dbContext.Produtos);
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> GetProduto(string id)
        {
            Produto? produto = dbContext
                .Produtos
                .FirstOrDefault(p => p.id == id);
            
            if (produto is null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<Produto> CreateProduto(ProdutoDTO novoProdutoDTO)
        {
            Produto novoProduto = new Produto(novoProdutoDTO.nome, novoProdutoDTO.descricao, novoProdutoDTO.preco, novoProdutoDTO.opinioes = []);

            dbContext.Produtos.Add(novoProduto);
            dbContext.SaveChanges();

            return CreatedAtAction(nameof(CreateProduto), novoProduto);
        }

        [HttpGet("{id}/opinioes")]
        public ActionResult<IEnumerable<string>> GetProdutoOpinioes(string id)
        {
            Produto? produto = dbContext
                .Produtos
                .FirstOrDefault(p => p.id == id);

            if (produto is null)
            { 
                return NotFound();
            }

            return Ok(produto.opinioes);
        }


    }
}
