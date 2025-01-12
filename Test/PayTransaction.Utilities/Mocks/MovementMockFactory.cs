using PayTransaction.Application.Movement;
using PayTransaction.Utils.Models.Movement;

namespace PayTransaction.Utils.Mocks;

public abstract class MovementMockFactory : MockFactory
{
    public static (AddIncome, MovementExpected) CreateIncomeMock(int accountId)
    {
        var id = Faker.Random.Number(1, 2_000);
        var amount = Faker.Random.Double(100, 1_000);
        var expected = new MovementExpected(id, amount);
        
        return (new AddIncome(accountId, id, amount), expected);
    }
}