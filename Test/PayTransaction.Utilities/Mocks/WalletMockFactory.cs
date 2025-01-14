using PayTransaction.Application.Create;
using PayTransaction.Utils.Models.Account;

namespace PayTransaction.Utils.Mocks;

public abstract class WalletMockFactory : MockFactory
{
    public static (AddInvestmentWallet, WalletExpected) CreateWalletMock(int accountId)
    {
        var expected = new WalletExpected(accountId, 0);
        
        return (new AddInvestmentWallet(accountId), expected);
    }
}