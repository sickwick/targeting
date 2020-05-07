using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Shop.Database;
using Shop.Database.Interfaces;
using Shop.Database.Models;

namespace Shop.Web
{
    public sealed class ProductListHolder
    {
        private static readonly Lazy<ProductListHolder> _singleInstance =
            new Lazy<ProductListHolder>(()=>new ProductListHolder());

        public List<Product> ProductList;
        private IProductDataProvider _productDataProvider;

        private ProductListHolder()
        {
            _productDataProvider = new ProductDataProvider(new MemoryCache(new MemoryCacheOptions()));
            ProductList = _productDataProvider.GetProducts();
        }

        static ProductListHolder()
        {
            if (_singleInstance == null)
            {
                _singleInstance = new Lazy<ProductListHolder>();
            }
        }
        
        public static ProductListHolder GetInstance()
        {
            return _singleInstance.Value;
        }
    }
}