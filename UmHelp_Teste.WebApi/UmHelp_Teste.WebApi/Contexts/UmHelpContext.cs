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
                //optionsBuilder.UseSqlServer("Data Source=ANA\\SQLEXPRESS; initial catalog=UmHelp;");
                optionsBuilder.UseSqlServer("Data Source=DEV16\\SQLEXPRESS; initial catalog=UmHelp; user Id=sa; pwd=sa@132; ");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Adiciona implementos
            builder.Entity<TiposUsuarios>();

            builder.Entity<Descontos>();

            builder.Entity<Usuarios>();

            builder.Entity<Pedidos>();

            builder.Entity<Produtos>();
        }
    }
}
