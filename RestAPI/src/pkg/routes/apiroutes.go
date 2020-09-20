package routes

import (
	"github.com/gorilla/mux"
	"pkg/controllers"
)

var RegisterAPIRoutes = func(router *mux.Router) {
	router.HandleFunc("/testgo", controllers.GetTestAnswer).Methods("GET")
}
