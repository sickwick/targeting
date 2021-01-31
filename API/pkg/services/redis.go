package services

import "github.com/go-redis/redis"

var RedisClient = createRedisClient()

func createRedisClient() *redis.Client {
	redisOptions := Configuration.Redis
	redisClient := redis.NewClient(&redis.Options{
		Addr: "http://" + redisOptions.Host + ":" + redisOptions.Port,
	})

	return redisClient
}
