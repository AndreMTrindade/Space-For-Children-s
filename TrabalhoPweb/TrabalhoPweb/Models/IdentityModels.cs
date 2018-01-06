using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PWEB.Models;

namespace TrabalhoPweb.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Apelido { get; set; }
        public int Telemovel { get; set; } // verificar, porque no Diagram tem numeric
        public string PalavraChave { get; set; }
        public bool Tipo { get; set; }
        public DateTime? Data { get; set; }
        IList<Instituicao> Instituicao { get; set; }
        IList<Avaliacao> Avaliacao { get; set; }
        IList<Crianca> Crianca { get; set; }
        IList<Pagamento> Pagamento { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Crianca> Criancas { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Foto> Fotos { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}