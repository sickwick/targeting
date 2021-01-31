package models

type AppOptions struct {
	Server struct {
		Host string
		Port string
	}

	Database struct {
		Host string
		Port string
	}
}
