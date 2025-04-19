using PayTransaction.Core.Data;
using PayTransaction.Core.Entities;

namespace PayTransaction.Application.Create;

public class AddInvestmentWallet
    (int accountId) : ITransaction
{
    public void Execute()
    {
        var account = PayDb.GetAccount(accountId);
        
        if (account is null)
            throw new InvalidOperationException("Account not found");
        var wallet = new InvestmentWallet(account.Id, 0);
        account.LinkWallet(wallet);
        
        PayDb.AddWallet(wallet);
    }
}