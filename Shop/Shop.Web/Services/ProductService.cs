using System;
using System.Collections.Generic;
using Shop.Database;
using Shop.Database.MongoDB;
using Shop.Web.Interfaces;
using Shop.Web.Models;

namespace Shop.Web.Services
{
    public class ProductService: IProductService
    {
        private readonly DatabaseBase _databaseBase;

        public ProductService(DatabaseBase databaseBase)
        {
            _databaseBase = databaseBase;
        }
        public List<Product> GetAllProducts()
        {
            throw new System.NotImplementedException();
        }

        public Product GetProduct(long article)
        {
            throw new System.NotImplementedException();
        }

        public Sizes GetSizes(long article)
        {
            throw new System.NotImplementedException();
        }

        public bool AddNewProduct(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}