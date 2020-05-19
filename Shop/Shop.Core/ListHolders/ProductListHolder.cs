using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Microsoft.Extensions.DependencyInjection;
using Shop.Core.DataProviders;
using Shop.Core.Interfaces.DataProviders;
using Shop.Core.Models;

namespace Shop.Core.ListHolders
{
    public sealed class ProductListHolder
    {
        private static readonly Lazy<ProductListHolder> _singleInstance =
            new Lazy<ProductListHolder>(()=>new ProductListHolder());

        public List<Product> ProductList;
        private IProductDataProvider _productDataProvider;
        private static IServiceProvider _provider;

        private ProductListHolder()
        {
            _productDataProvider = _provider.GetService<IProductDataProvider>();
            ProductList = _productDataProvider.GetProducts();
        }

        static ProductListHolder()
        {
            if (_singleInstance == null)
            {
                _singleInstance = new Lazy<ProductListHolder>();
            }
        }
        
        public static ProductListHolder GetInstance(IServiceProvider provider)
        {
            _provider = provider;
            return _singleInstance.Value;
        }
    }
}