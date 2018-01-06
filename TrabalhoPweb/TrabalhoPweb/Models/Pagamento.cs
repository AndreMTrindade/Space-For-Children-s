using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using PWEB.Models;
using TrabalhoPweb.Models;

namespace PWEB.Models
{
    [Table("Pagamento")]
    public class Pagamento
    {
        [Key]
        public int IdPagamento { get; set; }
        public Instituicao instituicao { get; set; }
        public ApplicationUser utilizador { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
    }
}