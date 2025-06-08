using Avaliacoes.Models;

namespace Avaliacoes.DTO
{
    public class OpiniaoDTO
    {
        public DateTime data { get; set; }
        public string id_produto { get; set; }
        public string nomeCliente { get; set; }
        public double nota { get; set; }
        public string opiniao { get; set; }
        public List<string> comentarios { get; set; }
    }
}
