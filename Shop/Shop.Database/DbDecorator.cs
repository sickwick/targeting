using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Database
{
    public abstract class DbDecorator : DatabaseBase
    {
        private readonly DatabaseBase _databaseBase;

        public DbDecorator(DatabaseBase databaseBase)
        {
            _databaseBase = databaseBase;
        }

        public override Task<List<TModel>> GetDatabaseList<TModel>()
        {
            return _databaseBase.GetDatabaseList<TModel>();
        }
    }
}