using System.Globalization;

namespace PayTransaction.Application.Services.Payment;

public class PaypalService
{
    public void Pay(string paymentId, decimal amount)
    {
        var result = string.Format(CultureInfo.GetCultureInfo("pt-BR"),
            "[{0}] {1:C2}", paymentId, amount);

        Console.WriteLine(result);
    }
}