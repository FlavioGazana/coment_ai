using Avaliacoes.Models;

namespace Avaliacoes.DTO
{
    public class ProdutoDTO //a dto serve para que não seja necessário expor a nossa model que está vinculada ao banco de dados
    {
        public string nome { get; set; }
        public string descricao { get; set; }
        public double preco { get; set; }
        public List<Opiniao> opinioes { get; set; }
    }
}
