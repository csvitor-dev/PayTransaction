using PayTransaction.Core.Entities;

namespace PayTransaction.Core.Data;

public static class PayDb
{
    private static readonly Dictionary<int, Account> Accounts = [];

    public static Account? GetAccount(int accountId)
        => Accounts.GetValueOrDefault(accountId);
}