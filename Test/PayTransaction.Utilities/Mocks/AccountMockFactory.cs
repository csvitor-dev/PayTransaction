using PayTransaction.Application.Create;
using PayTransaction.Utils.Models.Account;

namespace PayTransaction.Utils.Mocks;

public abstract class AccountMockFactory : MockFactory
{
    private static int MaxId { get; set; } = Faker.Random.Number(1, 1_000);

    public static (AddAccount, AccountExpected) CreateAccountMock()
    {
        var id = MaxId++;
        var balance = Faker.Random.Double(max: 2_000);
        var expected = new AccountExpected(id, balance);

        return (new AddAccount(id, balance), expected);
    }
}