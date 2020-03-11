using DesafioUmHelp.WebApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioUmHelp.WebApi.Context
{
    public class UmHelpContext : DbContext
    {
        public DbSet<TiposUsuarios> TiposUsuarios { get; set; }
        public DbSet<Descontos> Descontos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Produtos> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=DEV1\\SQLEXPRESS; initial catalog=Senatur_Tarde; user Id=sa; pwd=sa@132;");
                //optionsBuilder.UseSqlServer("Data Source=DEV16\\SQLEXPRESS; initial catalog=Senatur_Tarde; user Id=sa; pwd=sa@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //TODO: FAZER IMPLEMENTAÇÃO DE REGISTROS PEDIDOS NA DA DOCUMENTAÇÃO
            builder.Entity<TiposUsuarios>();

            builder.Entity<Descontos>();

            builder.Entity<Usuarios>();

            builder.Entity<Produtos>();
        }
    }
}
