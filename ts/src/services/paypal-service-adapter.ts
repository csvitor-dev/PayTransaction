import { PaypalService } from "./paypal-service";
import { PaymentService } from "../domain/contracts/payment-service";
import { Payment } from "../domain/models/payment";

export class PaypalServiceAdapter implements PaymentService {
  public constructor(private readonly service: PaypalService) {}

  processPayment(payment: Payment): void {
    console.log("-- Adapter [start] --");

    const { amount } = payment;
    const paymentId = payment.id.toString();

    this.service.pay(paymentId, amount);

    console.log("Payment successfully processed.");
    console.log(payment.description);

    console.log("-- Adapter [end] --");
  }
}
