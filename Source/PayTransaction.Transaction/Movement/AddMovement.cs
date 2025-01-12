using PayTransaction.Core.Data;

namespace PayTransaction.Application.Movement;

public abstract class AddMovement
    (int accountId) : ITransaction
{
    protected abstract Core.Entities.Movement MakeMovement();
    
    public void Execute()
    {
        var account = PayDb.GetAccount(accountId);
        
        if (account is null)
            throw new InvalidOperationException("Account not found");
        var movement = MakeMovement();
        movement.Transact(account);
        
        account.AddMovement(movement);
    }
}