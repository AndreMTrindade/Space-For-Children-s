using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TrabalhoPweb.Models;

namespace PWEB.Models
{
    [Table("Avaliacao")]
    public class Avaliacao
    {
        
        [Key]
        public int IdAvalicao { get; set; }
        public ApplicationUser utilizador  { get; set; }
        public Instituicao instituicao { get; set; }
        public DateTime Data { get; set; }
        public int Limpeza { get; set; }
        public int Organizacao { get; set; }
        public int Empatia { get; set; }
        public int ClassificacaoGeral { get; set; }
        public string Comentario { get; set; }
    }
}