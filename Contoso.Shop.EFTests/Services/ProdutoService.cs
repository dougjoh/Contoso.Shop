﻿using Contoso.Shop.EFTests.Controllers;
using Contoso.Shop.EFTests.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.Shop.EFTests.Services
{

    public interface IProdutoService
    {
        List<Produto> ObterTodos(string termoPesquisa);
        Produto Criar(CriarProdutoDto dto);
    }

    public class ProdutoService : IProdutoService
    {
        private readonly ShopContext shopContext;

        public ProdutoService(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public Produto Criar(CriarProdutoDto dto)
        {
            var produto = new Produto
            {
                Nome = dto.Nome,
                Preco = dto.Preco,
                CriadoEm = DateTimeOffset.Now
            };
            shopContext.Produtos.Add(produto);

            shopContext.SaveChanges();

            return produto;
        }

        public List<Produto> ObterTodos(string termoPesquisa)
        {
            if (string.IsNullOrWhiteSpace(termoPesquisa))
            {
                return shopContext.Produtos.ToList();
            }

            return shopContext.Produtos.
                Where(p => p.Nome.Contains(termoPesquisa)).ToList();
        }
    }

    
}
