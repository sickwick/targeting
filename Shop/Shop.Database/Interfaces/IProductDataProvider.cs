using System.Collections.Generic;
using Shop.Database.Models;

namespace Shop.Database.Interfaces
{
    public interface IProductDataProvider
    {
        List<Product> GetProducts();
    }
}