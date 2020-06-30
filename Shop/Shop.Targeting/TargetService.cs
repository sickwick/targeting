using System.Collections.Generic;
using Shop.Storage.Models;
using Shop.Targeting.TargetingModels;

namespace Shop.Targeting
{
    public class TargetService
    {
        public List<Product> GetUserHistory()
        {
            return null;
        }

        public void AddProductInHistory(long article)
        {
            
        }

        public List<Product> GetMoreInterestingProducts()
        {
            
            return null;
        }

        private ProductTargetingModel ConvertModelToTargetingModel(Product model)
        {
            var targetingModel = new ProductTargetingModel();

            return targetingModel;
        }

        private List<ProductTargetingModel> ConvertProductListToTargetingModelList(List<Product> products)
        {
            var targetingModels = new List<ProductTargetingModel>();
            foreach (var product in products)
            {
                targetingModels.Add(ConvertModelToTargetingModel(product));
            }

            return targetingModels;
        }
        
        
    }
}