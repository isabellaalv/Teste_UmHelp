using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioUmHelp.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Obrigatório email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Obrigatório senha")]
        public string Senha { get; set; }
    }
}
