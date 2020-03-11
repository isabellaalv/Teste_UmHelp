using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioUmHelp.WebApi.Domain
{
    //Define nome da tabela no banco
    [Table("Produtos")]
    public class Produtos
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
        [ForeignKey("Id")]
        public Usuarios Usuarios { get; set; }

        public int IdDesconto { get; set; }

        [ForeignKey("Id")]
        public Descontos Descontos { get; set; }
    }
}
