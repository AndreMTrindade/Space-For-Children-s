using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TrabalhoPweb.Models;

namespace PWEB.Models
{
    [Table("Instituicao")]
    public class Instituicao{
        [Key]
        public int IdInstituicao { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Concelho { get; set; }
        public string Distrito { get; set; }
        public string Agrupamento { get; set; }
        public string Descricao { get; set; }
        public int Telefone { get; set; }// verificar, porque no Diagram tem numeric
        public int Fax { get; set; }// verificar, porque no Diagram tem numeric
        public bool Ativo { get; set; }
        public bool Tipo { get; set; }
        public decimal ValorMensalBase { get; set; }
        public DateTime Inscricacao { get; set; }
        public DateTime FInscricao { get; set; }

        IList<ApplicationUser> administradores { get; set; }
        IList<Pagamento> pagamentos { get; set; }
        IList<Crianca> criancas { get; set; }
        IList<Avaliacao> avaliacoes { get; set; }
        IList<Servico> servicos { get; set; }
        IList<Foto> fotos { get; set; }
    }
}