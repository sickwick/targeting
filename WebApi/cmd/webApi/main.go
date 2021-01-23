package main

import (
	"github.com/gin-gonic/gin"
	"github.com/sickwick/api"
)

func main() {
	r := gin.Default()
	r.GET("api/products", api.GetAllProducts)
	r.GET("api/products/product", api.GetProduct)
	r.Run() // listen and serve on 0.0.0.0:8080 (for windows "localhost:8080")
}
