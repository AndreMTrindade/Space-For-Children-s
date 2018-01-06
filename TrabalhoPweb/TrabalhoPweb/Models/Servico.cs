using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PWEB.Models
{
    [Table("Servico")]
    public class Servico
    {
        [Key]
        public int IdServico { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int IdadeMinima { get; set; }
        public decimal ValorMensal { get; set; }

        IList<Instituicao> instituicoes { get; set; }
    }
}