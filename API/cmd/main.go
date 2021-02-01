package main

import (
	"errors"
	"fmt"
	"github.com/sickwick/SneakerShop/API/pkg/server"
	. "github.com/sickwick/SneakerShop/API/pkg/services"
	"log"
)

func main() {
	log.Fatal(run())
	//rds:= redis.NewClient(&redis.Options{
	//	Addr: "localhost:6379",
	//	Password: "",
	//	DB: 0,
	//})
	//err:=rds.Set("test", "qwerty", 0).Err()
	//if err!=nil{
	//	fmt.Println(err)
	//}
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
	server.CreateServer()
	//CreateRedisClient()

	return err
}
