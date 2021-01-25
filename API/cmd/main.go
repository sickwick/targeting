package main

import (
	"github.com/gin-gonic/gin"
	"github.com/go-redis/redis"
	"github.com/sickwick/SneakerShop/API/pkg/api"
)

func main() {
	r := gin.Default()
	//redisClient := services.CreateRedisClient("localhost", "6379")
	redisClient := redis.NewClient(&redis.Options{
		Addr: "localhost:6379",
	})
	r.GET("api/products", api.GetAllProducts)
	r.GET("api/products/product", func(context *gin.Context) { api.GetProduct(context, redisClient) })

	r.Run()
}
