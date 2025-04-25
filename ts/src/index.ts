import { PaymentService } from "./domain/contracts/payment-service";
import { Payment } from "./domain/models/payment";
import { PaypalService } from "./services/paypal-service";
import { PaypalServiceAdapter } from "./services/paypal-service-adapter";

const payment: Payment = {
  id: 238,
  description:
    "compra do livro 'Padrões de Projetos: Soluções Reutilizáveis de Software Orientados a Objetos'",
  amount: 148.5,
};

const adapter: PaymentService = new PaypalServiceAdapter(new PaypalService());
adapter.processPayment(payment);
