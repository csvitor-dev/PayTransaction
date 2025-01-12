namespace PayTransaction.Core.Entities;

public abstract class Movement(int id, double amount)
{
    public int Id { get; }= id;
    public double Amount { get; private set; } = amount;
    
    public abstract void Transact(Account account);
}