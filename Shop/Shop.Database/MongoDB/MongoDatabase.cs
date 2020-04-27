using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Shop.Database.MongoDB
{
    public class MongoDatabase: DbDecorator
    {
        private MongoDatabaseContext _databaseContext;
        public MongoDatabase(DatabaseBase databaseBase, MongoDatabaseContext databaseContext ):base(databaseBase)
        {
            _databaseContext = databaseContext;
        }

        public  override async Task<List<TModel>> GetDatabaseList<TModel>()
        {
            var userCollection = _databaseContext.GetCollection<TModel>()
                .Find(Builders<TModel>.Filter.Empty);
            if (userCollection == null) throw new NullReferenceException();

            return await userCollection.ToListAsync();
        }

        public override void AddInDatabase<TModel>(TModel model)
        {
            _databaseContext.GetCollection<TModel>().InsertOne(model);
        }
        
        public override void ChangeModelInDatabase<TModel>(TModel model, TModel newModel)
        {
            
        }
        
        public override void DeleteModelFromDatabase<TModel>(TModel model)
        {
        }
    }
}