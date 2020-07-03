using System.Collections.Generic;
using FN.Store.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FN.Store.UI.Controllers
{
    public class ProdutosController : Controller
    {
        public ViewResult Index(){
            var produtos = new List<Produto>(){
                new Produto(){Id=0, Nome="Picanha", Preco=98.9M, Qtde=2, Tipo="Alimento"},
                new Produto(){Id=0, Nome="Picanha", Preco=98.9M, Qtde=2, Tipo="Alimento"},
                new Produto(){Id=0, Nome="Picanha", Preco=98.9M, Qtde=2, Tipo="Alimento"},
            };

            return View(produtos);
        }
    }
}