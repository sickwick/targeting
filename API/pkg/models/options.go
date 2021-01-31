package models

import "time"

type AppOptions struct {
	Server struct {
		Host string
		Port string
	}

	Database struct {
		Host string
		Port string
	}

	Redis struct {
		Host       string
		Port       string
		Expiration time.Duration
	}
}
