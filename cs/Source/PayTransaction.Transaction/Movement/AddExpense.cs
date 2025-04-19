using PayTransaction.Core.Financial;

namespace PayTransaction.Application.Movement;

public class AddExpense
    (int accountId, int expenseId, double amount) : AddMovement(accountId, expenseId, amount)
{
    protected override Core.Entities.Movement MakeMovement(int id, double amount)
        => new Expense(id, amount);
}