package main

import (
	"github.com/gorilla/mux"
	"net/http"
	"pkg/routes"
)

func main() {
	r := mux.NewRouter()
	routes.RegisterAPIRoutes(r)
	http.Handle("/", r)
	http.ListenAndServe(":8090", r)
}
