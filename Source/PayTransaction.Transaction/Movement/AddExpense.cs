using PayTransaction.Core.Financial;

namespace PayTransaction.Application.Movement;

public class AddExpense
    (int accountId, int expenseId, double amount) : AddMovement(accountId)
{
    protected override Core.Entities.Movement MakeMovement()
        => new Expense(expenseId, amount);
}