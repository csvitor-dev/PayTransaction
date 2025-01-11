using Bogus;
using PayTransaction.Application.Create;
using PayTransaction.Utils.Models.Account;

namespace PayTransaction.Utils.Mocks;

public static class AccountMockFactory
{
    private static readonly Faker Faker = new();
    private static int MaxId { get; set; } = Faker.Random.Number(1, 1_000);

    public static (AddAccountTransaction, AccountExpected) CreateAccountMock()
    {
        var id = MaxId++;
        var balance = Faker.Random.Double(max: 2_000);
        var expected = new AccountExpected(id, balance);

        return (new AddAccountTransaction(id, balance), expected);
    }
}