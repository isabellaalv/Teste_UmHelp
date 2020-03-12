using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UmHelp_Teste.WebApi.Domains
{
    [Table("Usuarios")]
    public class Usuarios
    {
        //Define que é uma chave primária
        [Key]
        //Define o auto incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Define o tipo de dado
        [Column(TypeName = ("VARCHAR(255)"))]
        //Define que o campo é obrigatório
        [Required(ErrorMessage = "Email é obrigatório")]
        //Define tipo de dado
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Column(TypeName = ("VARCHAR(255)"))]
        [Required(ErrorMessage = "Senha é obrigatório")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public int IdTiposUsuarios { get; set; }

        //Define chave estrangeira
        [ForeignKey("IdTipoUsuarios")]
        public TiposUsuarios TiposUsuarios { get; set; }
    }
}
