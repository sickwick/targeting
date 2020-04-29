using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Database;

namespace Shop.Tests.Mocks
{
    public class DatabaseMock : DatabaseBase
    {
        public override Task<List<TModel>> GetDatabaseList<TModel>()
        {
            return new Task<List<TModel>>(null);
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