using System.Threading.Tasks;
using StackExchange.Redis;

namespace Shop.Redis
{
    public class RedisHelper
    {
        private IDatabase _redis;

        public RedisHelper(IConnection connection)
        {
            _redis = connection.CreateConnection();
        }

        public RedisValue GetValue(string key)
        {
            return _redis.StringGet(key);
        }

        public bool SetValue(string key, string value)
        {
            return _redis.StringSet(key, value);
        }
    }
}