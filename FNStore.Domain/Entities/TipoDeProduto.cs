using System;
using System.Collections.Generic;
using System.Text;

namespace FNStore.Domain.Entities
{
    public class TipoDeProduto : Entity
    {
        public string Nome { get; set; }

        public ICollection<Produto> Produtos { get; set; } = null;

        public TipoDeProduto(){}
    }

}
