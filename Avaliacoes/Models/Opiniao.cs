using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacoes.Models
{
    public class Opiniao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string id { get; set; }
        public DateTime data { get; set; }
        public string id_produto { get; set; }
        public string nomeCliente { get; set; }
        public double nota { get; set; }
        public string opiniao { get; set; }
        public List<string> comentarios { get; set; }

        private Opiniao() { }

        public Opiniao(DateTime data, string id_produto, string nomeCliente, double nota, string opiniao, List<string> comentarios)
        {
            this.data = data;
            this.id_produto = id_produto;
            this.nomeCliente = nomeCliente;
            this.nota = nota;
            this.opiniao = opiniao;
            this.comentarios = comentarios;

        }

    
    }
}
