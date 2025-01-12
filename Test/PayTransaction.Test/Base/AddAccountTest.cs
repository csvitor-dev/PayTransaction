using PayTransaction.Core.Data;
using PayTransaction.Utils.Mocks;
using PayTransaction.Utils.Models.Account;

namespace PayTransaction.Test.Base;

[TestFixture]
public class AddAccountTest
{
    [Test]
    public void Test_OnSuccess()
    {
        var (result, expected) = AccountMockFactory.CreateAccountMock();

        result.Execute();
        var account = PayDb.GetAccount(expected.Id);

        Assert.That(account, Is.Not.Null);
        Assert.That(account.Active, Is.EqualTo(expected.Active));
        Assert.That(account.CreatedOn, Is.EqualTo(expected.CreatedOn));
        Assert.That(account.Balance, Is.EqualTo(expected.Balance));
    }
}