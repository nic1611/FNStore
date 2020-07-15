using System;
using System.Collections.Generic;
using System.Text;

namespace FNStore.Domain.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }
    }

}
