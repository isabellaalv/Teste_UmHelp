using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioUmHelp.WebApi.Domain
{
    [Table("Produtos")]
    public class Produtos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string NomeProduto { get; set; }

        [Column(TypeName = "DECIMAL")]
        public decimal Valor { get; set; }

    }
}
