using PayTransaction.Core.Entities;

namespace PayTransaction.Core.Data;

public static class PayDb
{
    private static readonly Dictionary<int, Account> Accounts = [];
    private static readonly Dictionary<int, InvestmentWallet> Wallets = [];

    public static Account? GetAccount(int accountId)
        => Accounts.GetValueOrDefault(accountId);

    public static void AddAccount(Account account)
    {
        if (Accounts.TryAdd(account.Id, account) is false)
            throw new InvalidOperationException("Account already exists");
    }
    
    public static InvestmentWallet? GetWallet(int accountId)
        => Wallets.GetValueOrDefault(accountId);
    
    public static void AddWallet(InvestmentWallet wallet)
    {
        if (Wallets.TryAdd(wallet.AccountId, wallet) is false)
            throw new InvalidOperationException("Investment Wallet already exists");
    }
}