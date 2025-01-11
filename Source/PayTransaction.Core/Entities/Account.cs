namespace PayTransaction.Core.Entities;

public class Account(int id, double balance)
{
    public int Id => id;
    public bool Active { get; private set; } = true;
    public DateOnly CreatedOn => DateOnly.FromDateTime(DateTime.Now);
    public double Balance { get; private set; } = balance;
    
    public void Deposit(double amount)
        => Balance += amount;

    public double Withdraw(double amount)
    {
        Balance -= amount;
        return Balance;
    }
}