using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TrabalhoPweb.Models;

namespace PWEB.Models
{
    [Table("Crianca")]
    public class Crianca
    {
        [Key]
        public int IdCrianca { get; set; }
        public Instituicao instituicao { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public bool Aprov { get; set; }

        IList<ApplicationUser> utilizadores { get; set; }

    }
}