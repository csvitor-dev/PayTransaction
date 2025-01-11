using PayTransaction.Core.Data;

namespace PayTransaction.Test.Base;

[TestFixture]
public class AddAccountTransactionTest
{
    [Test]
    public void Test_OnSuccess()
    {
        var id = 1;
        var createdDate = new DateOnly(2025, 01, 11);
        var transaction = new AddAccountTransaction(id, 100.0);

        transaction.Execute();
        var account = PayDb.GetAccount(id);

        Assert.That(account, Is.Not.Null);
        Assert.That(account.Active, Is.True);
        Assert.That(account.CreatedOn, Is.EqualTo(createdDate));
        Assert.That(account.Balance, Is.EqualTo(100.0));
    }
}