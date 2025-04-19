package payment

import (
	"fmt"

	"github.com/csvitor-dev/PayTransaction/go/internal/entities"
	"github.com/fatih/color"
)

type PaypalServiceAdapter struct {
	service *paypalService
}

func NewPaypalServiceAdapter() *PaypalServiceAdapter {
	return &PaypalServiceAdapter{
		service: &paypalService{},
	}
}

func (adapter *PaypalServiceAdapter) ProcessPayment(payment entities.Payment) {
	color.HiYellow("-- Adapter [start] --")
	fmt.Println()

	paymentId := fmt.Sprint(payment.Id)
	amount := float64(payment.Amount)

	adapter.service.pay(paymentId, amount)

	color.HiGreen("Payment successfully processed.")
	fmt.Println(payment.Description)

	fmt.Println()
	color.HiYellow("-- Adapter [end] --")
}
