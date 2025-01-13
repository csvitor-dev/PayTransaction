using PayTransaction.Core.Financial;

namespace PayTransaction.Application.Movement;

public class AddIncome
    (int accountId, int incomeId, double amount) : AddMovement(accountId)
{
    protected override Core.Entities.Movement MakeMovement()
        => new Income(incomeId, amount);
}