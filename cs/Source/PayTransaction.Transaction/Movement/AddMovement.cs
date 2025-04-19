using PayTransaction.Core.Data;

namespace PayTransaction.Application.Movement;

public abstract class AddMovement
    (int accountId, int movementId, double amount) : ITransaction
{
    protected abstract Core.Entities.Movement MakeMovement(int id, double amount); // FACTORY METHOD
    
    public void Execute()
    {
        var account = PayDb.GetAccount(accountId);
        
        if (account is null)
            throw new InvalidOperationException("Account not found");
        var movement = MakeMovement(movementId, amount);
        movement.Transact(account);
        
        account.AddMovement(movement);
    }
}