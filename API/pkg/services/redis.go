package services

import (
	"github.com/go-redis/redis"
)

var RedisClient = createRedisClient()

func createRedisClient() *redis.Client {
	redisOptions := Configuration.Redis
	redisClient := redis.NewClient(&redis.Options{
		Addr:     redisOptions.Host + ":" + redisOptions.Port,
		Password: "",
		DB:       0,
	})

	return redisClient
}
