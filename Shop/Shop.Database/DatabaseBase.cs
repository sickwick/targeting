using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Database
{
    public abstract class DatabaseBase
    {
        public abstract Task<List<TModel>> GetDatabaseList<TModel>();
        public abstract void AddInDatabase<TModel>(TModel model);
        public abstract void ChangeModelInDatabase<TModel>(TModel model);
        public abstract void DeleteModelFromDatabase<TModel>(TModel model);
    }
}