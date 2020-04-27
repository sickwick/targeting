using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Shop.Database.Interfaces;
using Shop.Database.MongoDB;

namespace Shop.Database
{
    public class MongoDatabase: DbDecorator
    {
        private MongoDatabaseContext _databaseContext;
        public MongoDatabase(DatabaseBase database, MongoDatabaseContext databaseContext):base(database)
        {
            _databaseContext = databaseContext;
        }

        public override Task<List<TModel>> GetDatabaseList<TModel>()
        {
            return _databaseContext.GetCollection<TModel>().Find(Builders<TModel>.Filter.Empty).ToListAsync();
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