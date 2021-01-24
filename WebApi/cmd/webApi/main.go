package main

import (
	"github.com/gin-gonic/gin"
	"github.com/sickwick/api"
	"github.com/sickwick/services"
)

func main() {
	r := gin.Default()
	redisClient := services.CreateRedisClient("localhost", "6379")
	r.GET("api/products", api.GetAllProducts)
	r.GET("api/products/product", func(context *gin.Context) { api.GetProduct(context, &redisClient) })

	r.Run() // listen and serve on 0.0.0.0:8080 (for windows "localhost:8080")
}
