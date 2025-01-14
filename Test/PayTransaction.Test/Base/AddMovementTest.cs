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
        var (transferTransaction, expectedMovement) = MovementMockFactory
            .CreateTransferMock(expectedAccount.Id);
        
        accountTransaction.Execute();
        transferTransaction.Execute();
        var account = PayDb.GetAccount(expectedAccount.Id);
        var wallet = PayDb.GetWallet(expectedAccount.Id);
        var accountMovement = account?.GetMovement(expectedMovement.Id);
        var walletMovement = wallet?.GetMovement(expectedMovement.Id);
        
        
        Assert.That(account?.Movements, Is.Not.Empty);
        Assert.That(wallet?.Balance, Is.EqualTo(expectedMovement.Amount));
        Assert.That(accountMovement is Transfer, Is.True);
        Assert.That(walletMovement, Is.Not.Null);
        Assert.That(accountMovement?.Id, Is.EqualTo(expectedMovement.Id));
        Assert.That(accountMovement?.Amount, Is.EqualTo(expectedMovement.Amount));
        Assert.That(account.Balance,
            Is.EqualTo(expectedAccount.Balance - expectedMovement.Amount));
    }
}