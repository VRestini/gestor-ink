﻿using AppGestorInk.MVVM.Models;
namespace AppGestorInk.Services
{
    public interface IServiceItem
    {
        Task InitializeAsync();
        Task<IEnumerable<ItemProduto>> GetItemProdutoAsync();
        Task<IEnumerable<ItemProdutoUsado>> GetItemProdutosUsadosAsync();
        Task<IEnumerable<ItemProduto>> GetItemProdutoByProdutoIdAsync(int produtoId);
        Task<IEnumerable<ItemProduto>> GetItemProdutoNameAsync(string itemProduto);
        Task<int> AddItemProdutoAsync(ItemProduto itemProduto);
        Task<int> AddItemProdutoUsadoAsync(ItemProdutoUsado itemProdutoUsado);
        Task<int> DeleteItemProdutoAsync(ItemProduto itemProduto);
        Task<int> RefreshItemProdutoAsync(ItemProduto itemProduto);
    }
}
