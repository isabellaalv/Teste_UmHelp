using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UmHelp_Teste.WebApi.Domains
{
    [Table("Produto")]
    public class Produtos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string NomeProduto { get; set; }

        [Column(TypeName = "DECIMAL")]
        public decimal Valor { get; set; }

        [Column(TypeName = "DECIMAL")]
        public decimal QtdEstoque { get; set; }

        public void AlteraInformacoes(string nomeProduto, decimal valor)
        {
            NomeProduto = nomeProduto;
            Valor = valor;
        }


    }
}
