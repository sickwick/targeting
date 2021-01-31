package api

import (
	"encoding/json"
	"fmt"
	"github.com/sickwick/SneakerShop/API/pkg/models"
	"github.com/sickwick/SneakerShop/API/pkg/services"
	"io/ioutil"
	"log"
	"net/http"
)

func GetAllProducts(writer http.ResponseWriter, request *http.Request) {
	var response []models.Product
	dbOptions := services.Configuration.Database
	bdUrl := dbOptions.Host + ":" + dbOptions.Port
	log.Println(bdUrl)
	resp, err := http.Get("http://" + bdUrl + "/api/products")

	if err != nil {
		panic(err.Error())
	}

	if resp == nil {
		panic("response -  null")
	}

	defer func() {
		resp.Body.Close()
		if err := recover(); err != nil {
			writer.WriteHeader(http.StatusBadRequest)
			fmt.Fprint(writer, "Failed to load product list")
		}
		return
	}()

	if resp.StatusCode == 200 {
		body, err := ioutil.ReadAll(resp.Body)
		if err != nil {
			panic(err)
		}
		err = json.Unmarshal(body, &response)
		if err != nil {
			panic(err)
		}
		writer.WriteHeader(http.StatusOK)
		resp, err := json.Marshal(response)
		if err != nil {
			panic(err)
		}

		fmt.Fprintf(writer, string(resp))
		return
	}
}

//func GetProduct(writer http.ResponseWriter, request *http.Request, redisClient *redis.Client) {
//	var response models.Product
//	productArticle := context.Query("article")
//
//	if cachedData, err := redisClient.Get(productArticle).Result(); err == nil && cachedData != "" {
//		context.JSON(200, cachedData)
//		return
//	}
//
//	resp, err := http.Get("http://localhost:5000/api/products/product?article=" + productArticle)
//
//	if err != nil {
//	}
//
//	defer func() {
//		if err := recover(); err != nil {
//			fmt.Println(err)
//			context.JSON(404, gin.H{"error": err})
//			resp.Body.Close()
//		}
//	}()
//
//	if resp.StatusCode == 200 {
//		body, err := ioutil.ReadAll(resp.Body)
//		if err != nil {
//		}
//		err = json.Unmarshal(body, &response)
//		if err != nil {
//			fmt.Println(err)
//		}
//
//		redisResponse, err := json.Marshal(response)
//		if err != nil {
//			fmt.Println(err)
//		}
//
//		err = redisClient.Set(productArticle, redisResponse, 10*time.Hour).Err()
//		if err != nil {
//			fmt.Println(err)
//		}
//
//		context.JSON(200, response)
//		return
//	}
//	context.JSON(404, gin.H{
//		"message": "Article not found",
//	})
//}
