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
        public TipoDeProduto TipoDeProduto { get; set; } = null;

        public Produto(){}
    }
}
