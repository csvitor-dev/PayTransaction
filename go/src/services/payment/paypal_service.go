package payment

import (
	"fmt"

	"github.com/fatih/color"
)

type paypalService struct {
}

func (service *paypalService) pay(id string, amount float64) {
	color.HiYellow("-- Paypal Service [start] --")
	fmt.Println()

	result := fmt.Sprintf("Payment processed: [%s] $%.2f", id, amount)

	fmt.Println(result)

	fmt.Println()
	color.HiYellow("-- Paypal Service [end] --")
}
