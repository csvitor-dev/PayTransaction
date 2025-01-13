using PayTransaction.Core.Data;
using PayTransaction.Core.Financial;
using PayTransaction.Utils.Mocks;

namespace PayTransaction.Test.Base;

[TestFixture]
public class AddMovementTest
{
    [Test]
    public void Test_AddIncome_OnSuccess()
    {
        var (accountTransaction, expectedAccount) = AccountMockFactory.CreateAccountMock();
        var (incomeTransaction, expectedMovement) = MovementMockFactory
            .CreateIncomeMock(expectedAccount.Id);
        
        accountTransaction.Execute();
        incomeTransaction.Execute();
        var account = PayDb.GetAccount(expectedAccount.Id);
        var movement = account?.GetMovement(expectedMovement.Id);
        
        Assert.That(account?.Movements, Is.Not.Empty);
        Assert.That(movement is Income, Is.True);
        Assert.That(movement?.Id, Is.EqualTo(expectedMovement.Id));
        Assert.That(movement?.Amount, Is.EqualTo(expectedMovement.Amount));
        Assert.That(account?.Balance,
            Is.EqualTo(expectedAccount.Balance + expectedMovement.Amount));
    }

    [Test]
    public void Test_AddExpense_OnSuccess()
    {
        var (accountTransaction, expectedAccount) = AccountMockFactory.CreateAccountMock();
        var (expenseTransaction, expectedMovement) = MovementMockFactory
            .CreateExpenseMock(expectedAccount.Id);
        
        accountTransaction.Execute();
        expenseTransaction.Execute();
        var account = PayDb.GetAccount(expectedAccount.Id);
        var movement = account?.GetMovement(expectedMovement.Id);
        
        Assert.That(account?.Movements, Is.Not.Empty);
        Assert.That(movement is Expense, Is.True);
        Assert.That(movement?.Id, Is.EqualTo(expectedMovement.Id));
        Assert.That(movement?.Amount, Is.EqualTo(expectedMovement.Amount));
        Assert.That(account?.Balance,
            Is.EqualTo(expectedAccount.Balance - expectedMovement.Amount));
    }
    
    [Test]
    public void Test_AddTransfer_OnSuccess()
    {
        var (accountTransaction, expectedAccount) = AccountMockFactory.CreateAccountMock();
        var (expenseTransaction, expectedMovement) = MovementMockFactory
            .CreateTransferMock(expectedAccount.Id);
        
        accountTransaction.Execute();
        expenseTransaction.Execute();
        var account = PayDb.GetAccount(expectedAccount.Id);
        var movement = account?.GetMovement(expectedMovement.Id);
        
        Assert.That(account?.Movements, Is.Not.Empty);
        Assert.That(account?.Wallet, Is.EqualTo(expectedMovement.Amount));
        Assert.That(movement is Transfer, Is.True);
        Assert.That(movement?.Id, Is.EqualTo(expectedMovement.Id));
        Assert.That(movement?.Amount, Is.EqualTo(expectedMovement.Amount));
        Assert.That(account.Balance,
            Is.EqualTo(expectedAccount.Balance - expectedMovement.Amount));
    }
}