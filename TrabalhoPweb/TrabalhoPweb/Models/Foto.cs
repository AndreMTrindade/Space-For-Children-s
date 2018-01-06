using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PWEB.Models
{
    [Table("Foto")]
    public class Foto
    {
        [Key]
        public int IdFoto { get; set; }
        public Instituicao instituicao { get; set; }
    }
}