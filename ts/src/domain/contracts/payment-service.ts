import { Payment } from "../models/payment";

export interface PaymentService {
  processPayment(payment: Payment): void;
}
