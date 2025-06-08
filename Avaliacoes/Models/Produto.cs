using Avaliacoes.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacoes.Models
{
   public class Produto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public double preco { get; set; }
        public List<Opiniao> opinioes { get; set; }

        public Produto() { }
        public Produto(string nome, string descricao, double preco, List<Opiniao> opinioes)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.preco = preco;
            this.opinioes = opinioes;

        }

    
   }
}
