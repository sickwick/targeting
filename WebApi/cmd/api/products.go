package api

import (
	"encoding/json"
	"fmt"
	"github.com/gin-gonic/gin"
	"github.com/go-redis/redis"
	"github.com/sickwick/models"
	"io/ioutil"
	"net/http"
	"time"
)

func GetAllProducts(context *gin.Context) {
	var response []models.Product

	resp, err := http.Get("http://localhost:5000/api/products")

	if err != nil {
	}

	defer resp.Body.Close()

	if resp.StatusCode == 200 {
		body, err := ioutil.ReadAll(resp.Body)
		if err != nil {
		}
		err = json.Unmarshal(body, &response)
		if err != nil {
		}

		context.JSON(200, response)
		return
	}

	context.JSON(404, gin.H{
		"message": "Failed to load product list",
	})
}

func GetProduct(context *gin.Context, redisClient *redis.Client) {
	var response models.Product
	productArticle := context.Query("article")

	if cachedData, err := redisClient.Get(productArticle).Result(); err == nil && cachedData != "" {
		context.JSON(200, cachedData)
		return
	}

	resp, err := http.Get("http://localhost:5000/api/products/product?article=" + productArticle)

	if err != nil {
	}

	defer resp.Body.Close()

	if resp.StatusCode == 200 {
		body, err := ioutil.ReadAll(resp.Body)
		if err != nil {
		}
		err = json.Unmarshal(body, &response)
		if err != nil {
			fmt.Println(err)
		}

		redisResponse, err := json.Marshal(response)
		if err != nil {
			fmt.Println(err)
		}

		err = redisClient.Set(productArticle, redisResponse, 10*time.Hour).Err()
		if err != nil {
			fmt.Println(err)
		}

		context.JSON(200, response)
		return
	}
	context.JSON(404, gin.H{
		"message": "Article not found",
	})
}
