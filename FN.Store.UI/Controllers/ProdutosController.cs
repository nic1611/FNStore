using FNStore.Data.EF;
using FNStore.Domain.Contracts.Repositories;
using FNStore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FN.Store.UI.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly ITipoDeProdutoRepository repTipoDeProduto;
        private readonly IProdutoRepository repProduto;

        public ProdutosController(ITipoDeProdutoRepository repTipoDeProduto, IProdutoRepository repProduto)
        {
            this.repTipoDeProduto = repTipoDeProduto;
            this.repProduto = repProduto;
        }

        public ViewResult Index()
        {
            IList<Produto> produtos = null;

            produtos = repProduto.GetAll().ToList();

            return View(produtos);
        }

        [HttpGet]
        public ViewResult AddEdit(int? id)
        {
            Produto produto = new Produto();
            if (id != null)
            {
                produto = repProduto.Get((int) id);
            }

            var tipos = repTipoDeProduto.Get();
            ViewBag.Tipos = tipos;
            return View(produto);
        }

        [HttpPost]
        public IActionResult AddEdit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                if (produto.Id == 0)
                {
                    repProduto.Add(produto);
                }
                else
                {
                    repProduto.Edit(produto);
                }

                return RedirectToAction("Index");
            }
            var tipos = repTipoDeProduto.Get();
            ViewBag.Tipos = tipos;
            return View(produto);

        }

        [HttpDelete]
        public IActionResult DelProd(int id)
        {
            var produto = repProduto.Get(id);
            if (produto == null)
            {
                return NotFound();
            }
            repProduto.Delete(produto);

            return Ok();
        }


        protected override void Dispose(bool disposing)
        {
            repProduto.Dispose();
            repProduto.Dispose();
        }
    }
}