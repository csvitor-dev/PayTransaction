namespace PayTransaction.Core.Entities;

public class Account(int id, double balance)
{
    private readonly List<Movement> _movements = [];
    private InvestmentWallet? _wallet;
    
    public int Id { get; } = id;
    public bool Active { get; private set; } = true;
    public DateOnly CreatedOn { get; } = DateOnly.FromDateTime(DateTime.Now);
    public double Balance { get; private set; } = balance;
    
    public Movement[] Movements => _movements.ToArray();
    public double? Wallet => _wallet?.Balance;

    public void Deposit(double amount)
        => Balance += amount;

    public void Withdraw(double amount) 
        => Balance -= amount;
    
    public void LinkWallet(InvestmentWallet wallet)
        => _wallet = wallet;

    public void AddMovement(Movement movement)
        => _movements.Add(movement);

    public Movement? GetMovement(int movementId)
        => _movements.FirstOrDefault(movement => movement.Id == movementId);
}