using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FN.Store.UI.ViewModels.Produtos.Index
{
    public class ProdutoIndexVM
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public short Qtde { get; set; }

        public string Tipo { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;


    }
}
