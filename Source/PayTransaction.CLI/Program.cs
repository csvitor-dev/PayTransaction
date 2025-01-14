using PayTransaction.Application.Services.Payment;
using PayTransaction.Core.Contracts;
using PayTransaction.Core.Entities;

var payment = new Payment(238,
    "compra do livro 'Padrões de Projetos: Soluções Reutilizáveis de Software Orientados a Objetos'",
    148.5);

var paypal = new PaypalService();
IPaymentService adapter = new PaypalServiceAdapter(paypal);

adapter.ProcessPayment(payment);
