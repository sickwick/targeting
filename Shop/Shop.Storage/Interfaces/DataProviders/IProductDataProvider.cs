using System.Collections.Generic;
using Shop.Storage.Models;

namespace Shop.Storage.Interfaces.DataProviders
{
    public interface IProductDataProvider
    {
        List<Product> GetProducts();
        bool AddProductInDatabase(Product product);
    }
}