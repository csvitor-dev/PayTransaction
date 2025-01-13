using PayTransaction.Core.Entities;

namespace PayTransaction.Core.Financial;

public class Expense
    (int id, double amount) : Movement(id, amount)
{
    public override void Transact(Account account)
        => account.Withdraw(Amount);
}