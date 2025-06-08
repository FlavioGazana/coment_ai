using Avaliacoes.Database;
using Avaliacoes.DTO;
using Avaliacoes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpinioesController : Controller
    {
        
        private readonly AvaDbContext dbContext; //esse o parâmetro necessário para a injeção da dependência do banco de dados

        public OpinioesController(AvaDbContext dbContext) //esse é o construtor responsável pela injeção da dependência, no caso, para que o nosso controller
                                                          //possa ter acesso ao banco quase irrestrito ao banco de dados, podendo fazer crud completo
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Opiniao>> GetOpinioes()
        {
            return Ok(dbContext.Produtos);
        }

        [HttpGet("{id}")]
        public ActionResult<Opiniao> GetOpiniao(string id)
        {
            Opiniao? opiniao = dbContext
                .Opinioes
                .FirstOrDefault(o => o.id == id);
            
            if (opiniao is null)
            {
                return NotFound();
            }

            return Ok(opiniao);
        }

        [HttpPost]
        public ActionResult<Opiniao> CreateOpiniao(OpiniaoDTO novaOpiniaoDTO, string idProduto)
        {
            Produto? produto = dbContext
                .Produtos
                .FirstOrDefault(p => p.id == idProduto);

            if (produto is null)
            {
                return NotFound();
            }

            Opiniao novaOpiniao = new Opiniao(novaOpiniaoDTO.data, novaOpiniaoDTO.id_produto, novaOpiniaoDTO.nomeCliente,
                    novaOpiniaoDTO.nota, novaOpiniaoDTO.opiniao, novaOpiniaoDTO.comentarios ??= new List<string>());

            if (produto.opinioes == null)
            {
                produto.opinioes = new List<Opiniao>();
            }

            produto.opinioes.Add(novaOpiniao);


            dbContext.Opinioes.Add(novaOpiniao);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(CreateOpiniao), novaOpiniao);
        }

        


        //[HttpGet] //indicador de requisição get (extração de dados)
        //public ActionResult<IEnumerable<Produto>> GetOpinioes() //metódo para retornar todos os produtos
        //{
        //    return Ok(dbContext.Opinioes);
        //}

        //[HttpGet("{id}")]
        //public ActionResult<Produto> GetOp(string id)
        //{
        //    Produto? produto = dbContext
        //        .Produtos
        //        .FirstOrDefault(p => p.id == id);

        //    if (produto is null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(produto);
        //}

        //[HttpPost]
        //public ActionResult<Produto> CreateOpiniao(ProdutoDTO novoProdutoDTO)
        //{
        //    Produto novoProduto = new Produto(novoProdutoDTO.nome, novoProdutoDTO.descricao, novoProdutoDTO.preco, novoProdutoDTO.opinioes = []);

        //    dbContext.Produtos.Add(novoProduto);
        //    dbContext.SaveChanges();

        //    return CreatedAtAction(nameof(CreateProduto), novoProduto);
        //}
    }
}
