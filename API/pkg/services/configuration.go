package services

import (
	. "github.com/sickwick/SneakerShop/API/pkg/models"
	"github.com/tkanos/gonfig"
	"log"
	"os"
)

var Configuration = GetConfig()

func GetConfig() *AppOptions {
	config := AppOptions{}
	switch os.Getenv("ENVIRONMENT") {
	case "Dev":
		err := gonfig.GetConf("configs/appsettings.development.json", &config)
		if err != nil {
			log.Fatal(err.Error())
		}
	default:
		err := gonfig.GetConf("configs/appsettings.production.json", &config)
		if err != nil {
			log.Fatal(err.Error())
		}
	}

	return &config
}
