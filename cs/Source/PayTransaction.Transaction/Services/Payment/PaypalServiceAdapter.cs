using PayTransaction.Core.Contracts;

namespace PayTransaction.Application.Services.Payment;

public class PaypalServiceAdapter
    (PaypalService service) : IPaymentService
{
    public void ProcessPayment(Core.Entities.Payment payment)
    {
        var paymentId = payment.Id.ToString();
        var amount = Convert.ToDecimal(payment.Amount);
        
        service.Pay(paymentId, amount);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Payment successfully processed.");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(payment.Description);
    }
}
