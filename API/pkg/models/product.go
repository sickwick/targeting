package models

type Product struct {
	Article        int
	About          string
	Category       string
	Title          string
	Label          string
	Season         string
	Gender         bool
	Photos         []string
	Price          float32
	SizesAvailable []Sizes
}

type Sizes struct {
	Size         float32
	Availability Availability
}

type Availability struct {
	IsAvailable     bool
	QuantityInStock int
}
