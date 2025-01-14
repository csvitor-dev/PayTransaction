using PayTransaction.Core.Financial;

namespace PayTransaction.Application.Movement;

public class AddTransfer
    (int accountId, int transferId, double amount) : AddMovement(accountId)
{
    protected override Core.Entities.Movement MakeMovement()
        => new Transfer(transferId, amount);
}