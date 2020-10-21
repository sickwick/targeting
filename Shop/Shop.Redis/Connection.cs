using System.Collections;
using Shop.Storage.Models;
using StackExchange.Redis;

namespace Shop.Redis
{
    internal class Connection: IConnection
    {
        private ConnectionMultiplexer _redis;
        private IDatabase _database;
        private readonly RedisOptions _options;

        public Connection(IDatabase database, ICollection collection)
        {
            _database = database;
            _options = new RedisOptions();
        }

        public IDatabase CreateConnection()
        {
            _redis = ConnectionMultiplexer.Connect(_options.Connection.Host + ":" + _options.Connection.Port);
            _database = _redis.GetDatabase();
            

            return _database;
        }
    }
}