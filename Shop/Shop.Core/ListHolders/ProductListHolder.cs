using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Shop.Core.Interfaces.DataProviders;
using Shop.Core.Models;

namespace Shop.Core.ListHolders
{
    public sealed class ProductListHolder
    {
        private static readonly Lazy<ProductListHolder> SingleInstance =
            new Lazy<ProductListHolder>(() => new ProductListHolder());

        private readonly IProductDataProvider _productDataProvider;

        public List<Product> ProductList;

        static ProductListHolder()
        {
            if (SingleInstance == null) SingleInstance = new Lazy<ProductListHolder>();
        }

        private ProductListHolder()
        {
            _productDataProvider = ContainerConfig.ServiceProvider.GetService<IProductDataProvider>();
            ProductList = GetProductList();
        }

        public List<Product> GetProductList()
        {
            return _productDataProvider.GetProducts();
        }

        public void UpdateProductList()
        {
            ProductList = GetProductList();
        }

        public static ProductListHolder GetInstance()
        {
            return SingleInstance.Value;
        }
    }
}