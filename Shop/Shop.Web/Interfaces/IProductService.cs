using System.Collections.Generic;
using Shop.Web.Models;

namespace Shop.Web.Interfaces
{
    public interface IProductService
    {
        public List<Product> GetAllProducts();
        public Product GetProduct(long article);
        public Sizes GetSizes(long article);
        public bool AddNewProduct(Product product);
    }
}