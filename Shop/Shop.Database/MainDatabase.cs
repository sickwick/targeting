using System.Collections.Generic;
using System.Threading.Tasks;
using FakeLibrary;
using FakeLibrary.CopiedModels;

namespace Shop.Database
{
    public class MainDatabase: DatabaseBase
    {
        private readonly ProductsStub _productsStub;

        public MainDatabase()
        {
            _productsStub = new ProductsStub();
        }
        public override Task<List<TModel>> GetDatabaseList<TModel>()
        {
            var k = Task.FromResult(_productsStub.Products.SerializeObject().DeserializeObject<List<TModel>>()).Result;
            return Task.FromResult(_productsStub.Products.SerializeObject().DeserializeObject<List<TModel>>());
        }

        public override void AddInDatabase<TModel>(TModel model)
        {
            throw new System.NotImplementedException();
        }

        public override void ChangeModelInDatabase<TModel>(TModel model, TModel newModel)
        {
            throw new System.NotImplementedException();
        }

        public override void DeleteModelFromDatabase<TModel>(TModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}