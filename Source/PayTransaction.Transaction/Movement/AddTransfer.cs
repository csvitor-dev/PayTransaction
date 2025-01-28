using PayTransaction.Core.Financial;

namespace PayTransaction.Application.Movement;

public class AddTransfer
    (int accountId, int transferId, double amount) : AddMovement(accountId, transferId, amount)
{
    protected override Core.Entities.Movement MakeMovement(int id, double amount)
        => new Transfer(id, amount);
}