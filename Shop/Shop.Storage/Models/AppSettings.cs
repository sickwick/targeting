namespace Shop.Storage.Models
{
    public class AppSettings
    {
        public Logging Logging { get; set; }

        public RedisOptions RedisOptions { get; set; }

        public string AllowedHosts { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }

        public string Warning { get; set; }

        public string Error { get; set; }
    }

    public class RedisOptions
    {
        public Connection Connection { get; set; }
    }

    public class Connection
    {
        public string Host { get; set; }
        
        public string Port { get; set; }
    }
}