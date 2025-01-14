namespace PayTransaction.Core.Entities;

public class InvestmentWallet(int accountId, double balance)
{
    public int AccountId { get; } = accountId;
    public double Balance { get; private set; } = balance;
    public string[] Movements { get; } = [];
}