package main

import (
	"fmt"
	"github.com/gorilla/mux"
	"github.com/sickwick/SneakerShop/API/pkg/api"
	"net/http"
)

func main() {
	r := mux.NewRouter()
	r.HandleFunc("/api/products", api.GetAllProducts)
	//r.HandleFunc("api/products/product")
	//redisClient := services.CreateRedisClient("localhost", "6379")
	http.Handle("/", r)
	fmt.Println("Start server")
	http.ListenAndServe(":8081", nil)

}
