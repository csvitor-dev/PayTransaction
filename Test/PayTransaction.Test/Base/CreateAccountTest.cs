using PayTransaction.Core.Data;
using PayTransaction.Utils.Mocks;

namespace PayTransaction.Test.Base;

[TestFixture]
public class CreateAccountTest
{
    [Test]
    public void Test_AddAccount_OnSuccess()
    {
        var (result, expected) = AccountMockFactory.CreateAccountMock();

        result.Execute();
        var account = PayDb.GetAccount(expected.Id);

        Assert.That(account, Is.Not.Null);
        Assert.That(account.Active, Is.EqualTo(expected.Active));
        Assert.That(account.CreatedOn, Is.EqualTo(expected.CreatedOn));
        Assert.That(account.Balance, Is.EqualTo(expected.Balance));
    }

    [Test]
    public void Test_AddInvestmentWallet_OnSuccess()
    {
        var (accountTransaction, expectedAccount) = AccountMockFactory.CreateAccountMock();
        var (walletTransaction, expectedWallet) = WalletMockFactory
            .CreateWalletMock(expectedAccount.Id);

        accountTransaction.Execute();
        walletTransaction.Execute();
        var account = PayDb.GetAccount(expectedAccount.Id);
        var wallet = PayDb.GetWallet(expectedAccount.Id);

        Assert.That(wallet, Is.Not.Null);
        Assert.That(wallet.Movements, Is.Empty);
        Assert.That(wallet.AccountId, Is.EqualTo(expectedAccount.Id));
        Assert.That(account.Wallet, Is.EqualTo(expectedWallet.Balance));
    }
}