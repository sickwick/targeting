package api

import (
	"encoding/json"
	"fmt"
	"github.com/gorilla/mux"
	"github.com/sickwick/SneakerShop/API/pkg/models"
	. "github.com/sickwick/SneakerShop/API/pkg/services"
	"io/ioutil"
	"log"
	"net/http"
	"time"
)

func GetAllProducts(writer http.ResponseWriter, request *http.Request) {
	var dbUrl = Configuration.Database.Host + ":" + Configuration.Database.Port

	var response []models.Product
	log.Println(dbUrl)
	resp, err := http.Get("http://" + dbUrl + "/api/products")

	if err != nil {
		log.Println(err.Error())
	}

	defer resp.Body.Close()

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

func GetProduct(writer http.ResponseWriter, request *http.Request) {
	var dbUrl = Configuration.Database.Host + ":" + Configuration.Database.Port

	var modelResponse models.Product
	productArticle := mux.Vars(request)["article"]

	if cachedData, err := RedisClient.Get(productArticle).Result(); err == nil && cachedData != "" {
		writer.WriteHeader(http.StatusOK)
		fmt.Fprint(writer, cachedData)
		log.Println("return from here")
		return
	}

	resp, err := http.Get("http://" + dbUrl + "/api/products/product?article=" + productArticle)

	if err != nil {
		log.Println(err.Error())
	}

	defer resp.Body.Close()

	if resp.StatusCode == 200 {
		body, err := ioutil.ReadAll(resp.Body)
		if err != nil {
		}
		err = json.Unmarshal(body, &modelResponse)
		if err != nil {
			fmt.Println(err)
		}

		response, err := json.Marshal(modelResponse)
		if err != nil {
			fmt.Println(err)
		}

		answer := string(response)
		//err = RedisClient.Set("test", "test1", 0).Err()
		err = RedisClient.Set(productArticle, answer, Configuration.Redis.Expiration*time.Hour).Err()
		if err != nil {
			fmt.Println("redis - ", err)
		}

		writer.WriteHeader(http.StatusOK)
		fmt.Fprint(writer, answer)
		return
	}
	writer.WriteHeader(http.StatusNotFound)
	fmt.Fprint(writer, "Article not found")
}
