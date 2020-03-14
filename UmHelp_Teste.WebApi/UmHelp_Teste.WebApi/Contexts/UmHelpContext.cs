using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmHelp_Teste.WebApi.Domains;

namespace UmHelp_Teste.WebApi.Contexts
{
    public class UmHelpContext : DbContext
    {
        public DbSet<TiposUsuarios> TiposUsuarios { get; set; }
        public DbSet<Descontos> Descontos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Produtos> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!optionsBuilder.IsConfigured)
            {
                //colocar seu banco
                //optionsBuilder.UseSqlServer("Data Source=ANA\\SQLEXPRESS; initial catalog=UmHelp;");
                optionsBuilder.UseSqlServer("Data Source=DEV16\\SQLEXPRESS; initial catalog=UmHelp; user Id=sa; pwd=sa@132; ");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Adiciona implementos
            builder.Entity<TiposUsuarios>().HasData(new TiposUsuarios
            {
                Id = 1,
                Titulo = "Adm"
            }, new TiposUsuarios {
                Id = 2,
                Titulo = "Comum"
            });

            builder.Entity<Descontos>().HasData(new Descontos {
                Id = 1,
                Valor = 30,
                Ativo = true,
                IdUsuarios = 1
            }, new Descontos {
                Id = 2,
                Valor = 20,
                Ativo = true,
                IdUsuarios = 2
            });

            builder.Entity<Usuarios>().HasData(new Usuarios {
                Id = 1,
                Email = "adm@adm.com",
                Senha = "adm123",
                IdTiposUsuarios = 1
            }, new Usuarios {
                Id = 2,
                Email = "comum@comum.com",
                Senha = "comum132",
                IdTiposUsuarios = 2
            });

            builder.Entity<Pedidos>();

            builder.Entity<Produtos>().HasData(new Produtos {
                Id = 1,
                NomeProduto = "Candida",
                Valor = 50,
                QtdEstoque = 35
            }, new Produtos {
                Id = 2,
                NomeProduto = "Cloro",
                Valor = 60,
                QtdEstoque = 40
            });
        }
    }
}
