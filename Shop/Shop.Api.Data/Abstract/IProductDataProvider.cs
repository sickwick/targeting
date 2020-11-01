using System.Collections.Generic;
using Shop.Api.Data.Models;

namespace Shop.Api.Data.Abstract
{
    public interface IProductDataProvider
    {
        List<ProductDto> GetProducts();
        bool AddProductInDatabase(ProductDto product);
    }
}