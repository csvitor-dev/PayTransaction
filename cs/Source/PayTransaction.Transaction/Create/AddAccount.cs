using PayTransaction.Core.Data;
using PayTransaction.Core.Entities;

namespace PayTransaction.Application.Create;

public class AddAccount
    (int accountId, double initialBalance) : ITransaction
{
    public void Execute()
    {
        var account = new Account(accountId, initialBalance);

        PayDb.AddAccount(account);
    }
}