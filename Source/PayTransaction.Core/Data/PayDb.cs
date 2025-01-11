using PayTransaction.Core.Entities;

namespace PayTransaction.Core.Data;

public static class PayDb
{
    private static readonly Dictionary<int, Account> Accounts = [];

    public static Account? GetAccount(int accountId)
        => Accounts.GetValueOrDefault(accountId);

    public static void AddAccount(Account account)
    {
        if (Accounts.TryAdd(account.Id, account) is false)
            throw new InvalidOperationException("Account already exists");
    }
}