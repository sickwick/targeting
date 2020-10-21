using StackExchange.Redis;

namespace Shop.Redis
{
    public interface IConnection
    {
        public IDatabase CreateConnection();
    }
}