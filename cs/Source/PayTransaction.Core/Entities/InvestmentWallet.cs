namespace PayTransaction.Core.Entities;

public class InvestmentWallet(int accountId, double balance)
{
    private readonly List<Movement> _movements = [];
    
    public int AccountId { get; } = accountId;
    public double Balance { get; private set; } = balance;
    
    public Movement[] Movements => _movements.ToArray();
    
    public void Deposit(double amount)
        => Balance += amount;
    
    public void Withdraw(double amount)
        => Balance -= amount;
    
    public void AddMovement(Movement movement)
        => _movements.Add(movement);
    
    public Movement? GetMovement(int movementId)
        => _movements.FirstOrDefault(movement => movement.Id == movementId);
}