using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Database
{
    public class MainDatabase: DatabaseBase
    {
        public override Task<List<TModel>> GetDatabaseList<TModel>()
        {
            return null;
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