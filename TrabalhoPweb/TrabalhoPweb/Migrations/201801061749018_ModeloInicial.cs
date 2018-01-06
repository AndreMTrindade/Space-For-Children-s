namespace TrabalhoPweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeloInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Avaliacao",
                c => new
                    {
                        IdAvalicao = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Limpeza = c.Int(nullable: false),
                        Organizacao = c.Int(nullable: false),
                        Empatia = c.Int(nullable: false),
                        ClassificacaoGeral = c.Int(nullable: false),
                        Comentario = c.String(),
                        instituicao_IdInstituicao = c.Int(),
                        utilizador_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdAvalicao)
                .ForeignKey("dbo.Instituicao", t => t.instituicao_IdInstituicao)
                .ForeignKey("dbo.AspNetUsers", t => t.utilizador_Id)
                .Index(t => t.instituicao_IdInstituicao)
                .Index(t => t.utilizador_Id);
            
            CreateTable(
                "dbo.Instituicao",
                c => new
                    {
                        IdInstituicao = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Morada = c.String(),
                        Concelho = c.String(),
                        Distrito = c.String(),
                        Agrupamento = c.String(),
                        Descricao = c.String(),
                        Telefone = c.Int(nullable: false),
                        Fax = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        Tipo = c.Boolean(nullable: false),
                        ValorMensalBase = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Inscricacao = c.DateTime(nullable: false),
                        FInscricao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdInstituicao);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Apelido = c.String(),
                        Telemovel = c.Int(nullable: false),
                        PalavraChave = c.String(),
                        Tipo = c.Boolean(nullable: false),
                        Data = c.DateTime(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Crianca",
                c => new
                    {
                        IdCrianca = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Idade = c.Int(nullable: false),
                        Aprov = c.Boolean(nullable: false),
                        instituicao_IdInstituicao = c.Int(),
                    })
                .PrimaryKey(t => t.IdCrianca)
                .ForeignKey("dbo.Instituicao", t => t.instituicao_IdInstituicao)
                .Index(t => t.instituicao_IdInstituicao);
            
            CreateTable(
                "dbo.Foto",
                c => new
                    {
                        IdFoto = c.Int(nullable: false, identity: true),
                        instituicao_IdInstituicao = c.Int(),
                    })
                .PrimaryKey(t => t.IdFoto)
                .ForeignKey("dbo.Instituicao", t => t.instituicao_IdInstituicao)
                .Index(t => t.instituicao_IdInstituicao);
            
            CreateTable(
                "dbo.Pagamento",
                c => new
                    {
                        IdPagamento = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        instituicao_IdInstituicao = c.Int(),
                        utilizador_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdPagamento)
                .ForeignKey("dbo.Instituicao", t => t.instituicao_IdInstituicao)
                .ForeignKey("dbo.AspNetUsers", t => t.utilizador_Id)
                .Index(t => t.instituicao_IdInstituicao)
                .Index(t => t.utilizador_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Servico",
                c => new
                    {
                        IdServico = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        IdadeMinima = c.Int(nullable: false),
                        ValorMensal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdServico);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Pagamento", "utilizador_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Pagamento", "instituicao_IdInstituicao", "dbo.Instituicao");
            DropForeignKey("dbo.Foto", "instituicao_IdInstituicao", "dbo.Instituicao");
            DropForeignKey("dbo.Crianca", "instituicao_IdInstituicao", "dbo.Instituicao");
            DropForeignKey("dbo.Avaliacao", "utilizador_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Avaliacao", "instituicao_IdInstituicao", "dbo.Instituicao");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Pagamento", new[] { "utilizador_Id" });
            DropIndex("dbo.Pagamento", new[] { "instituicao_IdInstituicao" });
            DropIndex("dbo.Foto", new[] { "instituicao_IdInstituicao" });
            DropIndex("dbo.Crianca", new[] { "instituicao_IdInstituicao" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Avaliacao", new[] { "utilizador_Id" });
            DropIndex("dbo.Avaliacao", new[] { "instituicao_IdInstituicao" });
            DropTable("dbo.Servico");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Pagamento");
            DropTable("dbo.Foto");
            DropTable("dbo.Crianca");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Instituicao");
            DropTable("dbo.Avaliacao");
        }
    }
}
