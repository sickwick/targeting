using System;
using MongoDB.Driver;

namespace Shop.Database.MongoDB
{
    public class MongoDatabaseContext
    {
        private string _collectionName;
        private string _databaseName;

        public MongoDatabaseContext(string databaseName, string collectionName)
        {
            _databaseName = databaseName;
            _collectionName = collectionName;
        }

        private IMongoDatabase ConnectToDatabase()
        {
            var login = Environment.GetEnvironmentVariable("DB_LOGIN");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            var client = new MongoClient(
                $"mongodb+srv://{login}:{password}@helper-dlcu6.azure.mongodb.net/test?retryWrites=true&w=majority");
            var database = client.GetDatabase("Shop");
            return database;
        }

        public IMongoCollection<TModel> GetCollection<TModel>()
        {
            return ConnectToDatabase().GetCollection<TModel>("Products");
        }
    }
}