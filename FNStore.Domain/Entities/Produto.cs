using System;
using System.Collections.Generic;
using System.Text;

namespace FNStore.Domain.Entities
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public short Qtde { get; set; }

        public int TipoDeProdutoId { get; set; }
        public virtual TipoDeProduto TipoDeProduto { get; set; }
    }
}
