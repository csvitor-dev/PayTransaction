export class PaypalService {
  public pay(id: string, amount: number): void {
    console.log("-- Paypal Service [start] --");

    const result = `Payment processed: [${id}] $${amount}`;
    console.log(result);

    console.log("-- Paypal Service [end] --");
  }
}
