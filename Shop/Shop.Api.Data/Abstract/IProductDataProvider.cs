using System.Collections.Generic;
using Shop.Api.Core.Models;
using Shop.Api.Data.Models;

namespace Shop.Api.Data.Abstract
{
    public interface IProductDataProvider
    {
        List<ProductDTO> GetProducts();
        bool AddProductInDatabase(ProductDTO product);
    }
}