package contracts

import "github.com/csvitor-dev/PayTransaction/go/internal/entities"

type PaymentService interface {
	ProcessPayment(payment entities.Payment)
}
