using System.Collections.Generic;
using Shop.Api.Core.Models;
using Shop.Api.Data.Models;

namespace Shop.Api.Core.Abstract
{
    public interface IProductService
    {
        public List<ProductDto> GetAllProducts();
        public Product GetProduct(long article);
        public List<Sizes> GetSizes(long article);
        public bool AddNewProduct(Product product);
    }
}