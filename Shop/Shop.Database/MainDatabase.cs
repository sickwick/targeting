using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Database
{
    public class MainDatabase: DatabaseBase
    {
        public override Task<List<TModel>> GetDatabaseList<TModel>()
        {
            throw new System.NotImplementedException();
        }

        public override void AddInDatabase<TModel>(TModel model)
        {
            throw new System.NotImplementedException();
        }

        public override void ChangeModelInDatabase<TModel>(TModel model)
        {
            throw new System.NotImplementedException();
        }

        public override void DeleteModelFromDatabase<TModel>(TModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}