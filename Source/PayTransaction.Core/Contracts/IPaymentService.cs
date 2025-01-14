using PayTransaction.Core.Entities;

namespace PayTransaction.Core.Contracts;

public interface IPaymentService
{
    public void ProcessPayment(Payment payment);
}