package services

import "github.com/go-redis/redis"

func CreateRedisClient(host string, port string) redis.Client {
	client := redis.NewClient(&redis.Options{
		Addr: host + ":" + port,
	})

	return *client
}
