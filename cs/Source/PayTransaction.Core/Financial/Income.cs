using PayTransaction.Core.Entities;

namespace PayTransaction.Core.Financial;

public class Income(int id, double amount) : Movement(id, amount)
{
    public override void Transact(Account account)
        => account.Deposit(Amount);
}