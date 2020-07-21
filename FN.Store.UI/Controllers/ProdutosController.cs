using FN.Store.UI.ViewModels.Produtos.AddEdit;
using FN.Store.UI.ViewModels.Produtos.AddEdit.Maps;
using FN.Store.UI.ViewModels.Produtos.Index.Maps;
using FNStore.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            var produtos = repProduto.GetAll().ToProdutoIndexVM();

            return View(produtos);
        }

        [HttpGet]
        public ViewResult AddEdit(int? id)
        {
            var produto = new ProdutoAddEditVM();
            if (id != null)
            {
                produto = repProduto.Get((int)id).ToProdutoAddEditVM();
            }

            var tipos = repTipoDeProduto.Get();
            ViewBag.Tipos = tipos;
            return View(produto);
        }

        [HttpPost]
        public IActionResult AddEdit(ProdutoAddEditVM produtoVM)
        {
            var produto = produtoVM.ToProduto();

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