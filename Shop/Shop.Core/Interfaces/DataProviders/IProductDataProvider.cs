using System.Collections.Generic;
using Shop.Core.Models;

namespace Shop.Core.Interfaces.DataProviders
{
    public interface IProductDataProvider
    {
        List<Product> GetProducts();
    }
}