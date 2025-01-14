using PayTransaction.Core.Data;
using PayTransaction.Core.Entities;

namespace PayTransaction.Core.Financial;

public class Transfer
    (int id, double amount) : Movement(id, amount)
{
    public override void Transact(Account account)
    {
        var wallet = PayDb.GetWallet(account.Id);
        
        if (wallet is null)
            throw new InvalidOperationException("Investment wallet does not exist");
        account.Withdraw(Amount);
        wallet.Deposit(Amount);

        wallet.AddMovement(this);
    }
}