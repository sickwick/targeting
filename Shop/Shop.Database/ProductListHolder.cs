using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Serializers;
using Shop.Database.Interfaces;
using Shop.Database.Models;
using Unity;


namespace Shop.Database
{
    public sealed class ProductListHolder
    {
        private static readonly Lazy<ProductListHolder> _singleInstance =
            new Lazy<ProductListHolder>(() => new ProductListHolder());

        private readonly IProductDataProvider _productDataProvider;
        
        public List<Product> ProductList;

        private readonly Containers _containers;

        private ProductListHolder()
        {
            _containers = new Containers();
            // _productDataProvider = new ProductDataProvider();

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