using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioUmHelp.WebApi.Domain
{
    //Define nome da tabela que será criada no banco
    [Table("TiposUsuarios")]
    public class TiposUsuarios
    {
        //Define que será chave primária
        [Key]
        //Define que será auto incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Define o tipo de dado da coluna
        [Column(TypeName = "VARCHAR(255)")]
        //Define que é obrigatório a propriedade
        public string Titulo { get; set; }
    }
}
