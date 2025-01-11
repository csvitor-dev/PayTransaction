using PayTransaction.Core.Data;
using PayTransaction.Utils.Mocks;

namespace PayTransaction.Test.Base;

[TestFixture]
public class AddMovementTransactionTest
{
    [Test]
    public void Test_AddIncomeTransaction_OnSuccess()
    {
        var (accountTransaction, expectedAccount) = AccountMockFactory.CreateAccountMock();
        var (incomeTransaction, expectedMovement) = MovementMockFactory
            .CreateIncomeMock(expectedAccount.Id);
        
        accountTransaction.Execute();
        incomeTransaction.Execute();
        var account = PayDb.GetAccount(expectedAccount.Id);
        var movement = account.Movements.Get(expectedMovement.Id);
        
        Assert.That(account.Movements, Is.Not.Empty);
        Assert.That(movement.Amount, Is.EqualTo(expectedMovement.Amount));
        Assert.That(account?.Balance,
            Is.EqualTo(expectedAccount.Balance + expectedMovement.Amount));
    }
}