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

        [Column(TypeName = "DECIMAL")]
        [Required(ErrorMessage = "Valor é obrigatório")]
        public decimal Valor { get; set; }

        [Column(TypeName = "BIT")]
        public bool Ativo { get; set; }

        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuarios")]
        public Usuarios Usuarios { get; set; }
    }
}
