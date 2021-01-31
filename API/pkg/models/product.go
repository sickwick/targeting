package models

type Product struct {
	Article        int      `json:"article"`
	About          string   `json:"about"`
	Category       string   `json:"category"`
	Title          string   `json:"title"`
	Label          string   `json:"label"`
	Season         string   `json:"season"`
	Gender         bool     `json:"gender"`
	Photos         []string `json:"photo"`
	Price          float32  `json:"price"`
	SizesAvailable []Sizes  `json:"sizesAvailable"`
}

type Sizes struct {
	Size         float32      `json:"size"`
	Availability Availability `json:"availability"`
}

type Availability struct {
	IsAvailable     bool `json:"isAvailable"`
	QuantityInStock int  `json:"quantityInStock"`
}
