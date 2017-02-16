using Contoso.Shop.EFTests.Services;
using Contoso.Shop.EFTests.Shop;
using Contoso.Shop.EFTests.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.Shop.EFTests.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopContext shopContext;
        private readonly IProdutoService produtoService;

        public HomeController(ShopContext shopContext, IProdutoService produtoService)
        {
            this.shopContext = shopContext;
            this.produtoService = produtoService;
        }

        public IActionResult Index(ListaProdutosViewModel vm)
        {
            if(vm == null)
            {
                vm = new ListaProdutosViewModel();
            }

            vm.Produtos = produtoService.ObterTodos(vm.TermoPesquisa);

           

            return View(vm);
            //return Ok(produtos);
        }
        [HttpPost]
        public IActionResult Create([FromBody]CriarProdutoDto dto)
        {
            if( dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var produto = produtoService.Criar(dto);
            return Ok(produto);
        }
    }
}
