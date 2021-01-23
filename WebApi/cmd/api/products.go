package api

import (
	"encoding/json"
	"fmt"
	"github.com/gin-gonic/gin"
	"github.com/sickwick/models"
	"io/ioutil"
	"net/http"
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

func GetProduct(context *gin.Context) {
	var response models.Product
	productArticle := context.Query("article")
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

		context.JSON(200, response)
		return
	}
	context.JSON(404, gin.H{
		"message": "Article not found",
	})
}
