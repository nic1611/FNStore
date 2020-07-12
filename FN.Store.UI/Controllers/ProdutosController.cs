using System.Collections.Generic;
using System.Linq;
using FN.Store.UI.Data;
using FN.Store.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FN.Store.UI.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly FNStoreDataContext ctx;

        public ProdutosController(FNStoreDataContext ctx)
        {
            this.ctx = ctx;
        }

        public ViewResult Index()
        {
            IList<Produto> produtos = null;

            produtos = ctx.Produtos.Include(e => e.TipoDeProduto).ToList();

            return View(produtos);
        }

        [HttpGet]
        public ViewResult AddEdit(int? id)
        {
            Produto produto = new Produto();
            if (id != null)
            {
                produto = ctx.Produtos.Find(id);
            }

            var tipos = ctx.TipoDeProdutos.ToList();
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
                    ctx.Add(produto);
                }
                else
                {
                    ctx.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            var tipos = ctx.TipoDeProdutos.ToList();
            ViewBag.Tipos = tipos;
            return View(produto);

        }

        [HttpDelete]
        public IActionResult DelProd(int id)
        {
            var produto = ctx.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }
            ctx.Produtos.Remove(produto);
            ctx.SaveChanges();

            return Ok();
        }


        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
        }
    }
}