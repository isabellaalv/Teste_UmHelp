using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioUmHelp.WebApi.Domain
{
    //Define nome da tabela no banco
    [Table("Pedidos")]
    public class Pedidos
    {
        //Define que é uma chave primária
        [Key]
        //Define o auto incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Define o tipo de dado
        [Column(TypeName = ("DATETIME"))]
        //Define tipo de dado
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }

        [Column(TypeName = ("DECIMAL"))]
        [DataType(DataType.Currency)]
        public decimal ValorProduto { get; set; }

        public int IdUsuarios { get; set; }

        //Define chave estrangeira
        [ForeignKey("IdUsuarios")]
        public Usuarios Usuarios { get; set; }

        public int IdProduto { get; set; }

        [ForeignKey("IdProduto")]
        public Produtos Produtos { get; set; }

    }
}
