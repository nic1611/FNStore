using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FN.Store.UI.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage ="O {0} é obrigatório ")]
        [StringLength(40, ErrorMessage ="O limite do {0} é de {1} caractere")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A {0} é obrigatório ")]
        [StringLength(40, ErrorMessage = "O limite da {0} é de {1} caractere")]
        public string Senha { get; set; }

        public bool PermanecerLogado { get; set; }

        public string ReturnURL { get; set; }
    }
}
