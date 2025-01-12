namespace PayTransaction.Core.Entities;

public class Account(int id, double balance)
{
    private readonly List<Movement> _movements = [];
    public int Id { get; } = id;
    public bool Active { get; private set; } = true;
    public DateOnly CreatedOn { get; } = DateOnly.FromDateTime(DateTime.Now);
    public double Balance { get; private set; } = balance;
    
    public Movement[] Movements => _movements.ToArray();

    public void Deposit(double amount)
        => Balance += amount;

    public double Withdraw(double amount)
    {
        Balance -= amount;
        return Balance;
    }

    public void AddMovement(Movement movement)
        => _movements.Add(movement);

    public Movement? GetMovement(int movementId)
        => _movements.FirstOrDefault(movement => movement.Id == movementId);
}