package server

import (
	"fmt"
	"github.com/gorilla/mux"
	"github.com/sickwick/SneakerShop/API/pkg/api"
	"github.com/sickwick/SneakerShop/API/pkg/services"
	"log"
	"net/http"
)

func CreateServer() {
	r := CreateRouter()
	http.Handle("/", r)
	fmt.Println("Start server")
	log.Println(services.Configuration.Server.Port)
	http.ListenAndServe(":"+services.Configuration.Server.Port, nil)
}

func CreateRouter() *mux.Router {
	r := mux.NewRouter()
	r.HandleFunc("/api/products", api.GetAllProducts)
	r.HandleFunc("/test", func(writer http.ResponseWriter, request *http.Request) {
		writer.WriteHeader(http.StatusOK)
		fmt.Fprint(writer, "test func works")
	})
	r.HandleFunc("/api/products/product", api.GetProduct).Queries("article", "{article:[0-9]+}")
	return r
}
