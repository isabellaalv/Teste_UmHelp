using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioUmHelp.WebApi.Domain
{
    [Table("DescontosDeProdutos")]
    public class Descontos
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        [Required(ErrorMessage = "Tipo de desconto é obrigatório")]
        public string Tipo { get; set; }

        [Column(TypeName = "INT")]
        [Required(ErrorMessage = "Valor é obrigatório")]
        public int Valor { get; set; }

        [Column(TypeName = "BIT")]
        public bool Ativo { get; set; }

        public int IdUsuario { get; set; }

        [ForeignKey("Id")]
        public Usuarios Usuarios { get; set; }
    }
}
