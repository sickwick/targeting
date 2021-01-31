package services

import (
	. "github.com/sickwick/SneakerShop/API/pkg/models"
	"github.com/tkanos/gonfig"
	"log"
	"os"
)

var Configuration = AppOptions{}

func GetConfig() {

	switch os.Getenv("ENVIRONMENT") {
	case "Dev":
		err := gonfig.GetConf("configs/appsettings.development.json", &Configuration)
		if err != nil {
			log.Fatal(err.Error())
		}
	default:
		err := gonfig.GetConf("configs/appsettings.production.json", &Configuration)
		if err != nil {
			log.Fatal(err.Error())
		}
	}

	return
}
