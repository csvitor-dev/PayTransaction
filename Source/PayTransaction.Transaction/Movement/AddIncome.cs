using PayTransaction.Core.Financial;

namespace PayTransaction.Application.Movement;

public class AddIncome
    (int accountId, int incomeId, double amount) : AddMovement(accountId, incomeId, amount)
{
    protected override Core.Entities.Movement MakeMovement(int id, double amount)
        => new Income(id, amount);
}