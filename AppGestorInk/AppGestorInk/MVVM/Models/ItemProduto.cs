﻿using AppGestorInk.MVVM.Views;
using SQLite;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestorInk.MVVM.Models
{
    [Table( "ItemProduto")]
    public class ItemProduto :Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public int ProdutoId { get; set; }
        [NotNull]
        public double Preco { get; set; }
        [NotNull]
        public int Quantidade { get; set; }
        [NotNull]
        public DateTime DataValidade { get; set; }
    }
}
