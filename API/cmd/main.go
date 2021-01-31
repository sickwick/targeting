package main

import (
	"errors"
	"fmt"
	"github.com/gorilla/mux"
	"github.com/sickwick/SneakerShop/API/pkg/api"
	. "github.com/sickwick/SneakerShop/API/pkg/services"
	"log"
	"net/http"
)

func main() {
	log.Fatal(run())
	return
}

func run() error {
	var err error
	defer func() {

		if r := recover(); r != nil {
			switch x := r.(type) {
			case string:
				fmt.Println("here")
				err = errors.New(x)
			case error:
				err = x
			default:
				// Fallback err (per specs, error strings should be lowercase w/o punctuation
				err = errors.New("unknown panic")
			}
		}
	}()

	GetConfig()
	CreateServer()

	return err
}

func CreateServer() {
	r := CreateRouter()
	//redisClient := services.CreateRedisClient("localhost", "6379")
	http.Handle("/", r)
	fmt.Println("Start server")
	http.ListenAndServe(Configuration.Server.Port, nil)
}

func CreateRouter() *mux.Router {
	r := mux.NewRouter()
	r.HandleFunc("/api/products", api.GetAllProducts)
	r.HandleFunc("/test", func(writer http.ResponseWriter, request *http.Request) {
		writer.WriteHeader(http.StatusOK)
		fmt.Fprint(writer, "test func works")
	})
	//r.HandleFunc("api/products/product")
	return r
}
