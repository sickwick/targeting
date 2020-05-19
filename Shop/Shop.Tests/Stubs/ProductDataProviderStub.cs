using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Shop.Core.Interfaces.DataProviders;
using Shop.Core.Models;
using Shop.Database;

namespace Shop.Tests.Stubs
{
    public class ProductDataProviderStub: IProductDataProvider
    {
        private readonly DatabaseBase _databaseBase;
        private readonly IMemoryCache _memoryCache;
        
        public ProductDataProviderStub(IMemoryCache memoryCache)
        {
            _databaseBase = new MainDatabase();
            _memoryCache = memoryCache;
        }
        public List<Product> GetProducts()
        {
            return _databaseBase.GetDatabaseList<Product>().Result;
        }

        public void AddProductInDatabase(Product product)
        {
            
        }
    }
}