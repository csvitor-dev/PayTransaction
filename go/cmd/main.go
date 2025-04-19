package main

import (
	"github.com/csvitor-dev/PayTransaction/go/internal/contracts"
	"github.com/csvitor-dev/PayTransaction/go/internal/entities"
	"github.com/csvitor-dev/PayTransaction/go/src/services/payment"
)

func main() {
	pay := entities.Payment{
		Id:          238,
		Description: "compra do livro 'Padrões de Projetos: Soluções Reutilizáveis de Software Orientados a Objetos'",
		Amount:      148.5,
	}

	var adapter contracts.PaymentService = payment.NewPaypalServiceAdapter()
	adapter.ProcessPayment(pay)
}
